using Confluent.Kafka;

namespace Broker.Producers;

public class Producer : IProducer
{
    private readonly IProducer<Null, string> _producer;

    public Producer(IProducer<Null, string> producer)
    {
        _producer = producer;
    }

    public async Task ProduceAsync(string topicName, string message) =>
        await _producer.ProduceAsync(topicName, new Message<Null, string> { Value = message });
}

public class Producer<TMessage> : IProducer<TMessage> where TMessage : class
{
    private readonly IProducer<Null, TMessage> _producer;

    public Producer(IProducer<Null, TMessage> producer)
    {
        _producer = producer;
    }

    public async Task ProduceAsync(string topicName, TMessage message) =>
        await _producer.ProduceAsync(topicName, new Message<Null, TMessage> { Value = message });
}
