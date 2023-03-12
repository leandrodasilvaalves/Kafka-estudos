namespace Broker.Producers;

public interface IProducer
{
    Task ProduceAsync(string topicName, string message);
}

public interface IProducer<TMessage> where TMessage : class
{
    Task ProduceAsync(string topicName, TMessage message);
}
