using AspNet6Course.Data;
using AspNet6Course.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNet6Course.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private AppDbContext _DbContext;
        public CategoriesController(AppDbContext context)
        {
            _DbContext = context;
        }

        [HttpGet("{id}")]
        public async Task<Category> GetCategory(long id)
        {
            Category category = await _DbContext.Categories.Include(c => c.Products).FirstAsync(c => c.Id == id);
            if (category.Products != null)
            {
                foreach (Product product in category.Products)
                {
                    product.Category = null;
                }
            }
            return category;
        }

    }
}
