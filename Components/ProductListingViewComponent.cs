using AspNet6Course.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspNet6Course.Components
{
	[ViewComponent(Name = "VcCustom")]
	public class ProductListingViewComponent : ViewComponent
	{
		private AppDbContext _context;
		public ProductListingViewComponent(AppDbContext context)
		{
			_context = context;
		}
		public string Invoke()
		{
			return $"There are {_context.Products.Count()} Products";
		}
	}
}
