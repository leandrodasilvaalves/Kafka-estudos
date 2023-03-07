using Broker.Producers;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Orders.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderGenerator _generator;
        private readonly IProducer _producer;

        public OrdersController(IOrderGenerator generator, IProducer producer)
        {
            _generator = generator;
            _producer = producer;
        }

        [HttpPost]
        public async Task<IActionResult> Generate()
        {
            var order = _generator.Generate();
            await _producer.ProduceAsync("orders", order);
            return Ok(order);
        }
    }
}