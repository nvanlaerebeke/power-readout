using PowerReadOut;
using PowerReadOut.Receivers;

//Data source
IReceiver receiver = Environment.GetEnvironmentVariable("DataSource") == "Web" ? new WebReceiver() : new SerialPortReceiver();

//Start receiving data from the data source
var powerConsumptionData = new PowerConsumptionData(receiver);
powerConsumptionData.StartReceiving();

//Create the application
var app = WebApplication.CreateBuilder(args).Build();

//Configure web endpoints
app.MapGet("/metrics", () => powerConsumptionData.Get());
app.MapGet("/raw", () => powerConsumptionData.ToString());
app.MapGet("/", () => "Hello World");

//Start the application
app.Run();