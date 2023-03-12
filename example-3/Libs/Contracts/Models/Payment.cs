using System.Text.Json;
using System.Text.Json.Serialization;

namespace Contracts.Models
{
    public class Payment
    {
        [JsonConstructor]
        public Payment() { }
        public Payment(Order order, bool approved)
        {
            Id = Guid.NewGuid();
            OrderId = order.Id;
            CustomerId = order.Customer.Id;
            Approved = approved;
        }

        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public bool Approved { get; set; }

        public override string ToString() =>
            JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });

        public static implicit operator string(Payment order) => order.ToString();
    }
}