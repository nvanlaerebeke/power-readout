using PowerReadOut;
using PowerReadOut.Receivers;

var powerConsumptionData = new PowerConsumptionData(new WebReceiver());
powerConsumptionData.StartReceiving();

var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/metrics", () => 
    powerConsumptionData.Get()
);
app.Run();