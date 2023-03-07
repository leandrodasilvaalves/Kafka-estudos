using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var pConfig = configuration.GetSection("Producer").Get<ProducerConfig>();
var cConfig = configuration.GetSection("Consumer").Get<ConsumerConfig>();
var topicName = configuration.GetValue<string>("General:TopicName");

cConfig.EnableAutoCommit = false;

var assigned = false;
using var consumer = new ConsumerBuilder<Null, string>(cConfig)
    .SetPartitionsAssignedHandler((c, ps) => { assigned = true; })
    .Build();

using var producer = new ProducerBuilder<Null, string>(pConfig).Build();

Console.WriteLine($"Subscribing to topic '{topicName}'...");
consumer.Subscribe(topicName);

Console.WriteLine("Entering consume loop...");
while (true)
{
    var consumeResult = consumer.Consume(TimeSpan.FromSeconds(1));

    if (consumeResult != null)
    {
        Console.WriteLine($"Read value: '{consumeResult.Message.Value}' from partition {consumeResult.Partition} at offset {consumeResult.Offset}");
        consumer.Commit();
        // break;
    }

    if (!assigned)
    {
        Console.WriteLine("Waiting for assignment...");
        continue;
    }

    Console.WriteLine("Producing message with value: 'testvalue'...");
    await producer.ProduceAsync(topicName, new Message<Null, string> { Value = "testvalue" });
    await Task.Delay(1000);
}

// Console.WriteLine("Closing consumer...");
// consumer.Close();
