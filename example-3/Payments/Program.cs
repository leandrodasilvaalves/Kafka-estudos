using Broker.Consumers;
using Contracts.Models;
using Payments.Consumers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddConsumer<OrderConsumer, Order>(builder.Configuration, "Consumers");

var app = builder.Build();
app.Run();
