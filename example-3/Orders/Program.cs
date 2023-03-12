using Broker.Consumers;
using Broker.Producers;
using Contracts.Extensions;
using Contracts.Models;
using Orders.Consumers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddProducer(builder.Configuration);
builder.Services.AddConsumer<PaymentsConsumer, Payment>(builder.Configuration, "Consumers");
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
