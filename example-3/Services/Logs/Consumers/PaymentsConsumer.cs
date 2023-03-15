using Broker.Consumers;
using Contracts.Extensions;
using Contracts.Models;

namespace Logs.Consumers
{
    public class PaymentsConsumer : Consumer<Payment>
    {
        public PaymentsConsumer(IServiceProvider provider)
            : base(provider, "payments") { }

        public override Task ConsumeAsync(Payment message, CancellationToken stoppingToken)
        {
            ConsoleHelper.WriteLine("[Info -> Payment]: {0}", message, ConsoleColor.Cyan);
            return Task.CompletedTask;
        }
    }
}