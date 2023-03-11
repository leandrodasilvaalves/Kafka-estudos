using Broker.Consumers;
using Confluent.Kafka;
using Contracts.Extensions;
using Contracts.Models;

namespace Emails.Consumers
{
    public class OrderConsumer : Consumer<Order>
    {
        public OrderConsumer(IConsumer<Null, Order> consumer)
            : base(consumer, "orders") { }

        public override Task ConsumeAsync(Order message, CancellationToken stoppingToken)
        {
            ConsoleHelper.WriteLine("[Order]: {0}", message.ToString(), ConsoleColor.Cyan);
            return Task.CompletedTask;
        }
    }
}