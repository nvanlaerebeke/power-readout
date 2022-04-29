using PowerReadOut;

var powerConsumptionData = new PowerConsumptionData();
powerConsumptionData.StartReceiving();

var app = WebApplication.CreateBuilder(args).Build();
app.MapGet("/metrics", () => powerConsumptionData.Get());
app.Run();