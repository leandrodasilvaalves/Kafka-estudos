namespace Broker.Producers;

public interface IProducer
{
    Task ProduceAsync(string topicName, string message);
}
