using Broker.Consumers;
using Broker.Producers;
using Contracts.Extensions;
using Contracts.Models;
using Orders.Consumers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddEnvironmentVariables();

builder.Services
    .ConfigureProducers(builder.Configuration)
    .AddProducer();

builder.Services
    .ConfigureConsumers(builder.Configuration, "Consumers")
    .AddConsumer<PaymentsConsumer, Payment>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOrderGenerator();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
