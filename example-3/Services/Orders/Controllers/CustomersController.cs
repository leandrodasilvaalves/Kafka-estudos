using Broker.Producers;
using Contracts;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Orders.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IGenerator _generator;
        private readonly IProducer<Customer> _producer;

        public CustomersController(IGenerator generator, IProducer<Customer> producer)
        {
            _generator = generator;
            _producer = producer;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateCustomer()
        {
            var customer = _generator.GenerateCustomer();
            await _producer.ProduceAsync("customers", customer);
            return Ok(customer);
        }
    }
}