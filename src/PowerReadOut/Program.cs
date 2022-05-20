using PowerReadOut;
using PowerReadOut.Receivers;

var powerConsumptionData = new PowerConsumptionData(new SerialPortReceiver());
powerConsumptionData.StartReceiving();

var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/metrics", () =>
    powerConsumptionData.Get()
);

app.MapGet("/", () => "Hello World");

app.Run();