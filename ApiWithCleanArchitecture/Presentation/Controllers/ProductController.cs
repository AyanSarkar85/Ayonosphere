using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
        /*
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetProductByID(id);
            return Ok(product);
        }*/

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _productService.InsertNewProduct(product);
            return CreatedAtAction(nameof(Get), product.Id);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if (product == null)
            {
                return NoContent();
            }
            _productService.UpdateProduct(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
