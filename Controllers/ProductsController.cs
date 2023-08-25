using AspNet6Course.Data;
using AspNet6Course.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNet6Course.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private AppDbContext _DbContext;
        public ProductsController(AppDbContext context)
        {
            _DbContext = context;
        }

        [HttpGet]
        public IAsyncEnumerable<Product> GetProducts()
        {
            return _DbContext.Products.AsAsyncEnumerable();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(long id)
        {
            Product product = await _DbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                await _DbContext.Products.AddAsync(product);
                await _DbContext.SaveChangesAsync();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public void UpdateProduct([FromBody] Product product)
        {
            _DbContext.Products.Update(product);
            _DbContext.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteProductById(long id)
        {
            _DbContext.Products.Remove(new Product { Id = id });
            _DbContext.SaveChanges();
        }

        // api/products/redirect
        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            //return Redirect("/api/products/1");
            return RedirectToAction("GetProductById", new { Id = 5 });
        }
    }
}
