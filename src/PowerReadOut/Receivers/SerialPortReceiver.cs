using System.IO.Ports;

namespace PowerReadOut.Receivers;

/// <summary>
///     Class that receives data from a serial port
/// </summary>
internal class SerialPortReceiver : IReceiver, IDisposable
{
    /// <summary>
    ///     Baud rate used by the P1 port on the digital meter
    /// </summary>
    private const int BAUD_RATE = 115200;

    /// <summary>
    ///     A slash represents the start of the data
    /// </summary>
    private const byte SLASH = 47;

    /// <summary>
    ///     Serial port that will be read from
    /// </summary>
    private readonly SerialPort _serialPort;

    /// <summary>
    ///     Current telegram that's being received
    /// </summary>
    private Telegram _telegram;

    /// <summary>
    ///     Action that will be called when a complete telegram was received
    /// </summary>
    private Action<Telegram>? _telegramReceived;

    /// <summary>
    /// Class constructor that sets up the Serial port
    /// </summary>
    public SerialPortReceiver()
    {
        _telegram = new Telegram();
        _serialPort = new SerialPort(Port, BAUD_RATE);
        _serialPort.Handshake = Handshake.XOnXOff;
    }

    /// <summary>
    /// Returns the serial port path on the host to read from
    ///
    /// Default: /dev/ttyUSB0
    ///
    /// To change the port set the 'SerialPort' environment variable
    /// </summary>
    private string Port => !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SerialPort"))
        ? Environment.GetEnvironmentVariable("SerialPort")!
        : "/dev/ttyUSB0";

    /// <summary>
    /// Dispose of the serial port resources 
    /// </summary>
    public void Dispose()
    {
        _serialPort.Dispose();
    }

    /// <summary>
    /// Starts receiving/listening for data and run the telegramReceived when a Telegram is complete
    /// </summary>
    /// <param name="telegramReceived"></param>
    /// <returns></returns>
    public Task StartReceiving(Action<Telegram> telegramReceived)
    {
        return Task.Run(() =>
        {
            _telegramReceived = telegramReceived;
            _serialPort.Open();
            _serialPort.DataReceived += serialPort_DataReceived;
        });
    }

    /// <summary>
    /// Method called when the serial port receives data
    ///
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs eventArgs)
    {
        var data = new byte[_serialPort.BytesToRead];
        _serialPort.Read(data, 0, data.Length);
        foreach (var item in data)
        {
            //signals the beginning of a telegram
            if (SLASH == item)
            {
                _telegram = new Telegram();
            }
            else
            {
                if (!_telegram.HasStarted())
                {
                    continue;
                }
            }

            //If the telegram is already complete, don't do anything
            if (_telegram.IsComplete())
            {
                continue;
            }

            //Add data to the telegram
            _telegram.Add(item);

            //If the telegram is complete (and valid), let the application know
            if (_telegram.IsComplete())
            {
                if (_telegram.IsValid() && _telegramReceived != null)
                {
                    _telegramReceived(_telegram);
                }
            }
        }
    }
}