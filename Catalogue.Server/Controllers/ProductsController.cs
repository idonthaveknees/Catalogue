using Catalogue.Server.Models;
using Catalogue.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Server.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public Product AddProduct([FromBody] Product product)
        {
            product.Code = product.Code.ToUpper();
            _productRepository.AddProduct(product);
            return product;
        }
    }
}
