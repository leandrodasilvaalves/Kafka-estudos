using Broker.Consumers;
using Contracts.Extensions;
using Contracts.Models;

namespace Emails.Consumers
{
    public class PaymentsConsumer : Consumer<Payment>
    {
        public PaymentsConsumer(IServiceProvider provider)
            : base(provider, "payments") { }

        public override Task ConsumeAsync(Payment message, CancellationToken stoppingToken)
        {
            ConsoleHelper.WriteLine("[Email -> Payment]: {0}", message.Id, ConsoleColor.Cyan);
            return Task.CompletedTask;
        }
    }
}