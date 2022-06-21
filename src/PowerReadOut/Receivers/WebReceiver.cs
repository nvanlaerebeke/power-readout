namespace PowerReadOut.Receivers;

internal class WebReceiver : IReceiver
{
    private readonly HttpClient _httpClient;

    public WebReceiver()
    {
        _httpClient = new HttpClient();
    }

    /// <summary>
    ///     Number of seconds to wait to poll
    ///     Default: 1 second
    ///     To change this value set the PollInterval environment variable
    /// </summary>
    private int PollInterval => !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PollInterval"))
        ? int.Parse(Environment.GetEnvironmentVariable
            ("PollInterval")!)
        : 1;

    /// <summary>
    ///     Url to poll from
    /// </summary>
    private string Url => Environment.GetEnvironmentVariable("Url") ?? throw new Exception("Url not set");

    public async Task StartReceiving(Action<Telegram> telegramReceived)
    {
        await Task.Run(async () =>
        {
            while (true)
            {
                try
                {
                    var response = await _httpClient.GetAsync(Url);
                    var data = await response.Content.ReadAsByteArrayAsync();
                    var telegram = Parse(data);
                    if (telegram != null)
                    {
                        telegramReceived(telegram);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid telegram received from {Url}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while receiving telegram: {ex.Message}: {ex}");
                }
                finally
                {
                    await Task.Delay(PollInterval * 1000);
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