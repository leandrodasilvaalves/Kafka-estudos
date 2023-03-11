using Broker.Producers;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Orders.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrdersController : ControllerBase
    {
        private readonly IGenerator _generator;
        private readonly IProducer _producer;

        public OrdersController(IGenerator generator, IProducer producer)
        {
            _generator = generator;
            _producer = producer;
        }

        [HttpPost("orders")]
        public async Task<IActionResult> Generate()
        {
            var order = _generator.GenerateOrder();
            await _producer.ProduceAsync("orders", order);
            return Ok(order);
        }

        [HttpPost("customers")]
        public async Task<IActionResult> GenerateCustomer()
        {
            var customer = _generator.GenerateCustomer();
            await _producer.ProduceAsync("customers", customer);
            return Ok(customer);
        }

        [HttpPost("products")]
        public async Task<IActionResult> GenerateProduct()
        {
            var product = _generator.GenerateProduct();
            await _producer.ProduceAsync("products", product);
            return Ok(product);
        }
    }
}