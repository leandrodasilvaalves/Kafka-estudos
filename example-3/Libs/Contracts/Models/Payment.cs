using System.Text.Json;

namespace Contracts.Models
{
    public class Payment
    {
        public Payment(Order order, bool approved)
        {
            Id = Guid.NewGuid();
            OrderId = order.Id;
            CustomerId = order.Customer.Id;
            Approved = approved;
        }

        public Guid Id { get; }
        public Guid OrderId { get; }
        public Guid CustomerId { get; }
        public bool Approved { get; }
        public bool Repproved => !Approved;

        public override string ToString() =>
            JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            
        public static implicit operator string(Payment order) => order.ToString();
    }
}