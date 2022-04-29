namespace PowerReadOut;

internal class PowerConsumptionData
{
    private readonly Receiver _receiver = new();
    private DataRecord _current = new();

    public void StartReceiving()
    {
        _receiver.OnReceive(data =>
        {
            _current = data;
        });
    }

    public DataRecord Get()
    {
        return _current;
    }
}