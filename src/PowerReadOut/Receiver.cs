namespace PowerReadOut;

internal class Receiver
{
    private Action<DataRecord> _action;

    public void OnReceive(Action<DataRecord> action)
    {
        _action = action;
    }
    
    
}