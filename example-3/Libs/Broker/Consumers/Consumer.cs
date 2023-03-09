using Confluent.Kafka;

namespace Broker.Consumers
{

    public class Consumer : IConsumer
    {
        private readonly IConsumer<Null, string> _consumer;

        public Consumer(IConsumer<Null, string> consumer)
        {
            _consumer = consumer;
        }

        public async Task ConsumeAsync(string topicName, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("Inicializando consumer...");
            try
            {
                _consumer.Subscribe(topicName);
                while (!cancellationToken.IsCancellationRequested)
                {
                    var cResult = _consumer.Consume(cancellationToken);
                    Console.WriteLine($"Consumed event: [topic] : {topicName} | [partition] : {cResult.Partition.Value} | [key] : {cResult.Message.Key,-10} | [value] : {cResult.Message.Value}");
                    await Task.CompletedTask;
                }
            }
            catch (OperationCanceledException)
            {
                System.Console.WriteLine("Encerrando consumer");
            }
            finally
            {
                _consumer.Close();
            }
        }
    }
}