
using Broker.Consumers;
using Contracts.Models;
using LogsProcessor.Consumers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddConsumer<OrderConsumer, Order>(builder.Configuration, "Consumers");
builder.Services.AddConsumer<PaymentsConsumer, Payment>(builder.Configuration, "Consumers");
// builder.Services.AddConsumer<CustomerConsumer, Customer>(builder.Configuration, "Consumers");
// builder.Services.AddConsumer<ProductConsumer, Product>(builder.Configuration, "Consumers");

var app = builder.Build();
app.Run();