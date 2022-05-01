namespace PowerReadOut.Receivers;

internal interface IReceiver
{
    Task StartReceiving(Action<Telegram> telegramReceived);
}