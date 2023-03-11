using Broker.Consumers;
using Confluent.Kafka;
using Contracts.Extensions;
using Contracts.Models;

namespace Emails.Consumers
{
    public class ProductConsumer : Consumer<Product>
    {
        public ProductConsumer(IConsumer<Null, Product> consumer)
            : base(consumer, "products") { }

        public override Task ConsumeAsync(Product message, CancellationToken stoppingToken)
        {
            ConsoleHelper.WriteLine("[Product]: {0}", message.ToString(), ConsoleColor.Yellow);
            return Task.CompletedTask;
        }
    }
}