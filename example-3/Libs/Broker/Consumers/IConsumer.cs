namespace Broker.Consumers
{
    public interface IConsumer
    {
        Task ConsumeAsync(string topicName, CancellationToken cancellationToken);
    }
}