using Broker.Consumers;
using Contracts.Extensions;
using Contracts.Models;

namespace Logs.Consumers
{
    public class OrderConsumer : Consumer<Order>
    {
        public OrderConsumer(IServiceProvider provider)
        : base(provider, "orders") { }

        public override Task ConsumeAsync(Order message, CancellationToken stoppingToken)
        {
            ConsoleHelper.WriteLine("[Info -> order]: {0}", message, ConsoleColor.DarkGreen);
            return Task.CompletedTask;
        }
    }
}