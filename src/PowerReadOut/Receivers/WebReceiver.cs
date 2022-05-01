namespace PowerReadOut.Receivers;

internal class WebReceiver : IReceiver
{
    /// <summary>
    ///     Number of seconds to wait to poll
    /// </summary>
    private const int POLL_INTERVAL = 1;

    /// <summary>
    ///     Url to poll from
    /// </summary>
    private const string URL = "http://power.crazyzone.be/readout";

    private readonly HttpClient _httpClient;

    public WebReceiver()
    {
        _httpClient = new HttpClient();
    }

    public async Task StartReceiving(Action<Telegram> telegramReceived)
    {
        await Task.Run(async () =>
        {
            while (true)
            {
                try
                {
                    var response = await _httpClient.GetAsync(URL);
                    var data = await response.Content.ReadAsByteArrayAsync();
                    var telegram = Parse(data);
                    if (telegram != null)
                    {
                        telegramReceived(telegram);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid telegram received from {URL}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while receiving telegram: {ex.Message}: {ex}");
                }
                finally
                {
                    await Task.Delay(POLL_INTERVAL * 1000);
                }
            }
        });
    }

    private static Telegram? Parse(IEnumerable<byte> data)
    {
        var telegram = new Telegram();
        foreach (var b in data)
        {
            telegram.Add(b);
        }

        return telegram.IsComplete() && telegram.IsValid() ? telegram : null;
    }
}