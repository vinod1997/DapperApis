using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student.Api.POCO;
using Student.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger,IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GellAll()
        {
            var products = await _productRepository.GetAllProducts();
            return Ok(products);
        }

        //////[HttpGet]
        //////[Route("{id}")]
        //////public async Task<ActionResult<Product>> GetById(int id)
        //////{
        //////    var product = await _productRepository.GetById(id);
        //////    return Ok(product);
        //////}

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product entity)
        {
            await _productRepository.AddProduct(entity);
            return Ok(entity);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<Product>> GetByName(string name)
        {
            var product = await _productRepository.GetByName(name);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(Product entity, int id)
        {
            await _productRepository.UpdateProduct(entity, id);
            return Ok(entity);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productRepository.RemoveProduct(id);
            return Ok();
        }
    }
}
