using Broker.Consumers;
using Broker.Producers;
using Contracts.Extensions;
using Contracts.Models;

namespace Payments.Consumers
{
    public class OrderConsumer : Consumer<Order>
    {
        private readonly IProducer _producer;
        
        public OrderConsumer(IServiceProvider provider, IProducer producer)
            : base(provider, "orders") 
            => _producer = producer;

        public override Task ConsumeAsync(Order message, CancellationToken stoppingToken)
        {
            ConsoleHelper.WriteLine("[Payment -> Order]: {0}", message.Id, ConsoleColor.DarkYellow);
            var approved = message.Total % 2 == 0;
            var payment = new Payment(message, approved);
            return _producer.ProduceAsync("payments", payment);
        }
    }
}