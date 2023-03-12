using Broker.Consumers;
using Contracts.Extensions;
using Contracts.Models;

namespace Emails.Consumers
{
    public class OrderConsumer : Consumer<Order>
    {
        public OrderConsumer(IServiceProvider provider) 
            : base(provider, "orders"){}

        public override Task ConsumeAsync(Order message, CancellationToken stoppingToken)
        {
            ConsoleHelper.WriteLine("[Email -> Order]: {0}", message.Id, ConsoleColor.Cyan);
            return Task.CompletedTask;
        }
    }
}