using Broker.Consumers;
using Contracts.Models;
using Emails.Consumers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddConsumer<OrderConsumer, Order>(builder.Configuration, "Consumers");
builder.Services.AddConsumer<PaymentsConsumer, Payment>(builder.Configuration, "Consumers");

var app = builder.Build();
app.Run();
