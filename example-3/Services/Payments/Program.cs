using Broker.Consumers;
using Broker.Producers;
using Contracts.Models;
using Payments.Consumers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

builder.Services
    .ConfigureProducers(builder.Configuration, "Producers")
    .AddProducer();


builder.Services
    .ConfigureConsumers(builder.Configuration, "Consumers")
    .AddConsumer<OrderConsumer, Order>();

var app = builder.Build();
app.Run();
