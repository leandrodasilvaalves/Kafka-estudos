namespace Contracts.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}