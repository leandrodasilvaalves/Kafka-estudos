using Broker.Consumers;
using Confluent.Kafka;
using Contracts.Extensions;
using Contracts.Models;

namespace Emails.Consumers
{
    public class CustomerConsumer : Consumer<Customer>
    {
        public CustomerConsumer(IConsumer<Null, Customer> consumer)
            : base(consumer, "customers") { }

        public override Task ConsumeAsync(Customer message, CancellationToken stoppingToken)
        {
            ConsoleHelper.WriteLine("[Customer]: {0}", message.ToString(), ConsoleColor.Magenta);
            return Task.CompletedTask;
        }
    }
}