namespace Contracts.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Total => Price * Quantity;
    }
}   