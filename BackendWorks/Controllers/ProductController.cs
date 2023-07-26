using BackendWorks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _productContext;

        public ProductController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_productContext.Product == null)
            {
                return NotFound();
            }
            return await _productContext.Product.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            //first.Id = Empty;
            _productContext.Product.Add(product);
            await _productContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Product), new { id = product.Id }, product);
        }
    }
}
