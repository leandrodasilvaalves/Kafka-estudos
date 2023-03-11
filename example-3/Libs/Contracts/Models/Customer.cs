using System.Text.Json;

namespace Contracts.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override string ToString() =>
           JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });

        public static implicit operator string(Customer customer) => customer.ToString();
    }
}