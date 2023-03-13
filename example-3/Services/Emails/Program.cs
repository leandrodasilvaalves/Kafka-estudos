using Broker.Consumers;
using Contracts.Models;
using Emails.Consumers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddEnvironmentVariables();

builder.Services
    .ConfigureConsumers(builder.Configuration, "Consumers")
    .AddConsumer<OrderConsumer, Order>()
    .AddConsumer<PaymentsConsumer, Payment>();

var app = builder.Build();
app.Run();
