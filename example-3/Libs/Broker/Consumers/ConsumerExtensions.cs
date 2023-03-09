using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Broker.Consumers
{
    public static class ConsumerExtensions
    {
        public static IServiceCollection AddConsumer(this IServiceCollection self, IConfiguration config, string sectionName = "Kafka")
        {
            var cConfig = config.GetSection(sectionName).Get<ConsumerConfig>();
            self.AddSingleton<IConsumer<Null, string>>(new ConsumerBuilder<Null, string>(cConfig)
                .Build());

            self.AddSingleton<IConsumer, Consumer>();
            return self;
        }
    }
}