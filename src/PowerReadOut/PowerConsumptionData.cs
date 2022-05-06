using PowerReadOut.Receivers;

namespace PowerReadOut;

internal class PowerConsumptionData
{
    private readonly IReceiver _receiver;
    private DataRecord _current;

    public PowerConsumptionData(IReceiver receiver)
    {
        _receiver = receiver;
    }

    public void StartReceiving()
    {
        _receiver.StartReceiving(data =>
        {
            _current = DataRecord.FromBytes(data.GetData());
        });
    }

    public DataRecord Get()
    {
        return _current;
    }
}