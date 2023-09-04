using AspNet6Course.Data;
using AspNet6Course.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNet6Course.Components
{
	[ViewComponent(Name = "VcCustom")]
	public class ProductListingViewComponent : ViewComponent
	{
		private AppDbContext _context;
		public IEnumerable<Product> products;
		public ProductListingViewComponent(AppDbContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View(_context.Products.Include(p => p.Category).ToList());
		}
	}
}
