using Broker.Consumers;
using Contracts.Extensions;
using Contracts.Models;

namespace LogsProcessor.Consumers
{
    public class CustomerConsumer : Consumer<Customer>
    {
        public CustomerConsumer(IServiceProvider provider)
        : base(provider, "customers") { }

        public override Task ConsumeAsync(Customer message, CancellationToken stoppingToken)
        {
            ConsoleHelper.WriteLine("[Info -> customer]: {0}", message, ConsoleColor.DarkCyan);
            return Task.CompletedTask;
        }
    }
}