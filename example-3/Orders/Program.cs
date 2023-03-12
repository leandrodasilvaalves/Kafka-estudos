using Broker.Consumers;
using Broker.Producers;
using Contracts.Extensions;
using Contracts.Models;
using Orders.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProducer(builder.Configuration);
builder.Services.AddConsumer<PaymentsConsumer, Payment>(builder.Configuration, "Consumers");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOrderGenerator();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
