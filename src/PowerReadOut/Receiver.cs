using System.IO.Ports;

namespace PowerReadOut;

internal class Receiver
{
    /// <summary>
    /// Action that will be called when a complete telegram was received
    /// </summary>
    private readonly Action<Telegram> _telegramReceived;
    
    /// <summary>
    /// Serial port that will be read from
    /// </summary>
    private readonly SerialPort _serialPort;

    /// <summary>
    /// Current telegram that's being received
    /// </summary>
    private Telegram _telegram;

    private const byte SLASH = 47;
    
    public Receiver(Action<Telegram> telegramReceived)
    {
        _telegramReceived = telegramReceived;
        _telegram = new Telegram();
        _serialPort = new SerialPort("/dev/ttyUSB0", 115200);
        _serialPort.Handshake = Handshake.XOnXOff;
    }

    public void StartReceiving()
    {
        _serialPort.Open();
        _serialPort.DataReceived += serialPort_DataReceived;
    }

    private void serialPort_DataReceived(object s, SerialDataReceivedEventArgs e)
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
                if (_telegram.IsValid())
                {
                    _telegramReceived(_telegram);
                }
            }
        }
    }

    public void Dispose()
    {
        _serialPort.Dispose();
    }
}