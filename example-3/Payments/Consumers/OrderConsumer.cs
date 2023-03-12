using Broker.Consumers;
using Contracts.Extensions;
using Contracts.Models;

namespace Payments.Consumers
{
    public class OrderConsumer : Consumer<Order>
    {
        public OrderConsumer(IServiceProvider provider)
            : base(provider, "orders") { }

        public override Task ConsumeAsync(Order message, CancellationToken stoppingToken)
        {
            ConsoleHelper.WriteLine("[Payment -> Order]: {0}", message.ToString(), ConsoleColor.DarkYellow);
            return Task.CompletedTask;
        }
    }
}