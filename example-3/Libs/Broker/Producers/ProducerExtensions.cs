using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Broker.Producers;

public static class ProducerExtensions
{
    private static ProducerConfig ProducerConfig;
    public static IServiceCollection AddProducer(this IServiceCollection self, IConfiguration config, string sectionName = "Kafka")
    {
        ProducerConfig ??= config.GetSection(sectionName).Get<ProducerConfig>();
        ProducerConfig.SecurityProtocol = SecurityProtocol.Plaintext;

        self.AddSingleton<IProducer<Null, string>>(new ProducerBuilder<Null, string>(ProducerConfig).Build());
        self.AddSingleton<IProducer, Producer>();
        return self;
    }
}
