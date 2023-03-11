using System.Text.Json;

namespace Contracts.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Total => Price * Quantity;

        public override string ToString() =>
           JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });

        public static implicit operator string(Product customer) => customer.ToString();
    }
}   