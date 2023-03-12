
using Broker.Consumers;
using Contracts.Models;
using LogsProcessor.Consumers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddEnvironmentVariables();

builder.Services
    .ConfigureConsumers(builder.Configuration, "Consumers")
    .AddConsumer<OrderConsumer, Order>()
    .AddConsumer<PaymentsConsumer, Payment>()
    .AddConsumer<CustomerConsumer, Customer>()
    .AddConsumer<ProductConsumer, Product>();

var app = builder.Build();
app.Run();