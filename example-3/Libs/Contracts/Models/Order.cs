using System.Text.Json;

namespace Contracts.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
            Products = new List<Product>();
            Customer = new Customer();
        }
        public Guid Id { get; set; }
        public List<Product> Products { get; set; }
        public float Total => Products.Sum(p => p.Total);
        public Customer Customer { get; set; }

        public override string ToString() =>
            JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });

        public static implicit operator string(Order order) => order.ToString();
    }
}