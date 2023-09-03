using AspNet6Course.Data;
using AspNet6Course.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNet6Course.Pages
{
	public class EditModel : PageModel
	{
		private AppDbContext _context;
		public Product product;
		public EditModel(AppDbContext context)
		{
			_context = context;
		}
		public async Task OnGetAsync(long id)
		{
			product = await _context.Products.FindAsync(id);
		}

		public async Task<IActionResult> OnPostAsync(long id, decimal price)
		{
			Product product = await _context.Products.FindAsync(id);
			if (product != null)
			{
				product.price = price;
			}
			await _context.SaveChangesAsync();

			return RedirectToPage();
		}
	}
}
