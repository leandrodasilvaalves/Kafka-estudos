using Broker.Consumers;
using Contracts.Extensions;
using Contracts.Models;

namespace LogsProcessor.Consumers
{
    public class ProductConsumer : Consumer<Product>
    {
        public ProductConsumer(IServiceProvider provider)
        : base(provider, "products") { }

        public override Task ConsumeAsync(Product message, CancellationToken stoppingToken)
        {
            ConsoleHelper.WriteLine("[Info -> product]: {0}", message, ConsoleColor.DarkMagenta);
            return Task.CompletedTask;
        }
    }
}