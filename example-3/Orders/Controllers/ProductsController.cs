using Broker.Producers;
using Contracts;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Orders.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenerator _generator;
        private readonly IProducer<Product> _producer;

        public ProductsController(IGenerator generator, IProducer<Product> producer)
        {
            _generator = generator;
            _producer = producer;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateProduct()
        {
            var product = _generator.GenerateProduct();
            await _producer.ProduceAsync("products", product);
            return Ok(product);
        }
    }
}