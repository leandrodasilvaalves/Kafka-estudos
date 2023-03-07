using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Broker.Producers;

public static class ProducerExtensions
{
    public static IServiceCollection AddProducer(this IServiceCollection self, IConfiguration config, string sectionName = "Kafka")
    {
        var pConfig = config.GetSection(sectionName).Get<ProducerConfig>();
        self.AddSingleton<IProducer<Null, string>>(new ProducerBuilder<Null, string>(pConfig).Build());
        self.AddSingleton<IProducer, Producer>();
        return self;
    }
}
