namespace PowerReadOut;

internal class PowerConsumptionData
{
    private readonly Receiver _receiver;
    private DataRecord _current;

    public PowerConsumptionData()
    {
        _receiver = new Receiver(data =>
        {
            _current = DataRecord.FromBytes(data.GetData());
        });
    }

    public void StartReceiving()
    {
        _receiver.StartReceiving();
    }

    public DataRecord Get()
    {
        return _current;
    }
}