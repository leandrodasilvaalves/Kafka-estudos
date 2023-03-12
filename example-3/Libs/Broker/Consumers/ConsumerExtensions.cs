using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Broker.Consumers
{
    public static class ConsumerExtensions
    {
        private static ConsumerConfig ConsumerConfig;

        public static IServiceCollection ConfigureConsumers(this IServiceCollection self, IConfiguration config, string sectionName = "Kafka")
        {
            ConsumerConfig = config.GetSection(sectionName).Get<ConsumerConfig>();
            return self;
        }

        public static IServiceCollection AddConsumer<TConsumer, TMessage>(this IServiceCollection self)
            where TMessage : class
            where TConsumer : class, IConsumer<TMessage>, IHostedService
        {

            if(ConsumerConfig is null)
                throw new KafkaException(new Error(ErrorCode.Local_NotImplemented, "ConsumerConfig can't be null."));

            self.AddSingleton<IConsumer<Null, TMessage>>(new ConsumerBuilder<Null, TMessage>(ConsumerConfig)
                .SetValueDeserializer(CustomDeserializer<TMessage>.Instance())
                .Build());

            self.AddHostedService<TConsumer>();
            return self;
        }
    }
}