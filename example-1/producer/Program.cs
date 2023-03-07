using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

class Producer
{

    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Please provide the configuration file path as a command line argument");
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddIniFile(args[0])
            .Build();

        const string topic = "purchases";
        string[] users = { "eabara", "jsmith", "sgarcia", "jbernard", "htanaka", "awalther" };
        string[] items = { "book", "alarm clock", "t-shirts", "gift card", "batteries" };

        using (var producer = new ProducerBuilder<string, string>(configuration.AsEnumerable()).Build())
        {
            var numProduced = 0;
            Random rnd = new Random();
            // const int numMessages = 10;

            var random = new Random();
            while (true)
            {
                var user = users[rnd.Next(users.Length)];
                var item = items[rnd.Next(items.Length)];
                
                var partition = random.Next(0,5);
                producer.Produce(new TopicPartition(topic, new Partition(partition)), new Message<string, string> { Key = user, Value = item }, (deliveryReport) =>
                {
                    if (deliveryReport.Error.Code != ErrorCode.NoError)
                    {
                        Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                    }
                    else
                    {
                        Console.WriteLine($"Produced event: [topic] : {topic} | [partition] : {partition} | [key] : {user,-10} | [value] :  {item}");
                        numProduced += 1;
                    }
                });
                Thread.Sleep(500);
            }

            // producer.Flush(TimeSpan.FromSeconds(10));
            // Console.WriteLine($"{numProduced} messages were produced to topic {topic}");
        }
    }
}