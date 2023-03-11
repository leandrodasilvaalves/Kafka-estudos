using System.Text;
using System.Text.Json;
using Confluent.Kafka;

namespace Broker.Consumers
{
    public class CustomDeserializer<TObject> : IDeserializer<TObject> where TObject : class
    {
        private static CustomDeserializer<TObject> _instance;

        public TObject Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            var value = Encoding.ASCII.GetString(data);
            return JsonSerializer.Deserialize<TObject>(value);
        }

        public static CustomDeserializer<TObject> Instance()
        {
            if(_instance is null)
            {
                _instance = new CustomDeserializer<TObject>();
            }
            return _instance;
        }
    }
}