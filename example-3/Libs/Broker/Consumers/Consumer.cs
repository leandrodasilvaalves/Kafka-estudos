using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace Broker.Consumers
{
    public interface IConsumer<TMessage>  where TMessage : class
    {
        Task ConsumeAsync(TMessage message, CancellationToken stoppingToken);
    }

    public abstract class Consumer<TMessage> : BackgroundService, IConsumer<TMessage> where TMessage : class
    {
        private readonly string _topicName;
        private readonly string TName = typeof(TMessage).Name;
        private readonly IConsumer<Null, TMessage> _consumer;

        public Consumer(IConsumer<Null, TMessage> consumer, string topicName)
        {
            _consumer = consumer;
            _topicName = topicName;
        }

        public abstract Task ConsumeAsync(TMessage message, CancellationToken stoppingToken);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(async () =>
            {
                Console.WriteLine($"Inicializando consumer...[{_topicName}]");
                try
                {
                    _consumer.Subscribe(_topicName);
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        var result = _consumer.Consume(stoppingToken);
                        if(result is null)
                            continue;


                        Console.WriteLine($"Consumed event: [topic] : {_topicName} | [partition] : {result.Partition.Value} | [key] : {result.Message.Key,-10}");
                        await ConsumeAsync(result.Message.Value, stoppingToken);
                        _consumer.Commit();
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine($"Encerrando consumer...[{_topicName}]");
                }
                finally
                {
                    _consumer.Close();
                    _consumer.Dispose();
                }
                return Task.CompletedTask;
            });
        }
    }
}