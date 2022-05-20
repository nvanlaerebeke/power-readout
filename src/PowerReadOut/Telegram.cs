using System.Text;
using Force.Crc32;

namespace PowerReadOut;

internal class Telegram
{
    private const byte SLASH = 47;
    private const byte EXCLAMATION = 33;
    private readonly List<byte> _data = new();
    private int _endIndex;

    public void Add(byte data)
    {
        //All data for this telegram was already received
        if (_endIndex != 0 && _data.Count == _endIndex + 5)
        {
            if (char.IsControl(Convert.ToChar(data)))
            {
                return;
            }

            throw new Exception("Telegram is complete, unable to add extra data");
        }

        if (_data.Count == 0 && data != SLASH)
        {
            throw new Exception("Telegram start character is not correct");
        }

        //Add to data list
        _data.Add(data);

        //! signals the end
        if (EXCLAMATION == Convert.ToChar(data))
        {
            _endIndex = _data.Count - 1;
        }
    }

    public bool HasStarted()
    {
        return _data.Count > 0;
    }

    public bool IsComplete()
    {
        return _endIndex != 0 && _data.Count == _endIndex + 5;
    }

    public bool IsValid()
    {
        var arr = _data.ToArray();
        // last 4 bytes contains CRC
        Crc32Algorithm.ComputeAndWriteToEnd(arr);
        // transferring data or writing reading, and checking as final operation
        return Crc32Algorithm.IsValidWithCrcAtEnd(arr);
    }

    public byte[] GetData()
    {
        return _data.ToArray();
    }

    public override string ToString()
    {
        return IsComplete() && IsValid() ? Encoding.UTF8.GetString(_data.ToArray()) : string.Empty;
    }
}