using Bogus;
using Contracts.Models;
using Bogus.Extensions.Brazil;
using AutoFixture;
using System.Text.Json;

namespace Contracts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var generator = new Generator();
            var order = generator.GenerateOrder();
            Console.WriteLine(JsonSerializer.Serialize(order, new JsonSerializerOptions { WriteIndented = true }));
        }
    }

    public interface IGenerator
    {
        Order GenerateOrder();
        Customer GenerateCustomer();
        Product GenerateProduct();
    }

    public class Generator : IGenerator
    {
        private readonly Faker _faker;
        private readonly IFixture _fixture;

        public Generator()
        {
            _faker = new Faker("pt_BR");
            _fixture = new Fixture();
            RegisterCustomer();
            RegisterProduct();
            RegisterOrder();
        }

        private void RegisterOrder()
        {
            _fixture.Register(() => new Order
            {
                Id = Guid.NewGuid(),
                Customer = _fixture.Create<Customer>(),
                Products = _fixture.Create<List<Product>>(),
            });
        }

        private void RegisterProduct()
        {
            _fixture.Register(() => new Product
            {
                Id = Guid.NewGuid(),
                Quantity = _faker.Random.Int(min: 1, max: 20),
                Description = _faker.Commerce.ProductName(),
                Price = _faker.Random.Float(max: 250.00f),
            });
        }

        private void RegisterCustomer()
        {
            _fixture.Register(() => new Customer
            {
                Id = Guid.NewGuid(),
                Name = _faker.Person.FullName,
                Document = _faker.Person.Cpf(),
                PhoneNumber = _faker.Person.Phone,
                Email = _faker.Person.Email,
            });
        }

        public Order GenerateOrder() => _fixture.Create<Order>();

        public Customer GenerateCustomer() => _fixture.Create<Customer>();

        public Product GenerateProduct() => _fixture.Create<Product>();
    }
}