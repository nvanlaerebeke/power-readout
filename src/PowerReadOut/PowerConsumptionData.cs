using PowerReadOut.Receivers;

namespace PowerReadOut;

internal class PowerConsumptionData
{
    private readonly IReceiver _receiver;
    private DataRecord? _current;

    public PowerConsumptionData(IReceiver receiver)
    {
        _receiver = receiver;
    }

    public void StartReceiving()
    {
        _receiver.StartReceiving(
            data =>
            {
                try
                {
                    _current = DataRecord.FromBytes(data.GetData());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unable to get data: {ex.Message}: {ex.StackTrace}");
                }
            });
    }

    public DataRecord? Get()
    {
        if (_current == null)
        {
            Console.WriteLine("No data yet...");
        }
        return _current;
    }
}