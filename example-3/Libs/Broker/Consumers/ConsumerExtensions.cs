using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Broker.Consumers
{
    public static class ConsumerExtensions
    {
        private static ConsumerConfig ConsumerConfig;

        public static IServiceCollection AddConsumer<TConsumer, TMessage>(this IServiceCollection self, IConfiguration config, string sectionName = "Kafka")
            where TMessage : class
            where TConsumer : class, IConsumer<TMessage>, IHostedService
        {
            ConsumerConfig ??= config.GetSection(sectionName).Get<ConsumerConfig>();
            ConsumerConfig.SecurityProtocol = SecurityProtocol.Plaintext;

            self.AddSingleton<IConsumer<Null, TMessage>>(new ConsumerBuilder<Null, TMessage>(ConsumerConfig)
                .SetValueDeserializer(CustomDeserializer<TMessage>.Instance())
                .Build());

            self.AddHostedService<TConsumer>();
            return self;
        }
    }
}