using PowerReadOut;
using PowerReadOut.Receivers;

//Create the application
var app = WebApplication.CreateBuilder(args).Build();

try
{
    //Data source
    IReceiver receiver = Environment.GetEnvironmentVariable("DataSource") == "Web" ? new WebReceiver() : new SerialPortReceiver();

    //Start receiving data from the data source
    var powerConsumptionData = new PowerConsumptionData(receiver);
    powerConsumptionData.StartReceiving();
    
    //Configure web endpoints
    app.MapGet("/metrics", () => powerConsumptionData.Get());
    app.MapGet("/raw", () => powerConsumptionData.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

Console.WriteLine("Configure kubernetes liveness probes");
app.MapGet("/livez", () => "lives");
app.MapGet("/readyz", () => "lives");
app.MapGet("/healthz", () => "lives");

Console.WriteLine("Starting application");
app.Run();