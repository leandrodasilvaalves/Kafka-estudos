using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Broker.Producers;

public static class ProducerExtensions
{
    private static ProducerConfig ProducerConfig;
    public static IServiceCollection ConfigureProducers(this IServiceCollection self, IConfiguration config, string sectionName = "Kafka")
    {
        ProducerConfig = config.GetSection(sectionName).Get<ProducerConfig>();
        return self;
    }

    public static IServiceCollection AddProducer(this IServiceCollection self)
    {
        if(ProducerConfig is null)
            throw new KafkaException(new Error(ErrorCode.Local_NotImplemented, "ProducerConfig can't be null."));

        self.AddSingleton<IProducer<Null, string>>(new ProducerBuilder<Null, string>(ProducerConfig).Build());
        self.AddSingleton<IProducer, Producer>();
        return self;
    }
}
