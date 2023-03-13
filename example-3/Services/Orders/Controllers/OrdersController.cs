using Broker.Producers;
using Contracts;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Orders.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IGenerator _generator;
        private readonly IProducer<Order> _producer;

        public OrdersController(IGenerator generator, IProducer<Order> producer)
        {
            _generator = generator;
            _producer = producer;
        }

        [HttpPost]
        public async Task<IActionResult> Generate()
        {
            var order = _generator.GenerateOrder();
            await _producer.ProduceAsync("orders", order);
            return Ok(order);
        }
    }
}