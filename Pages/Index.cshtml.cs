using AspNet6Course.Data;
using AspNet6Course.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNet6Course.Pages
{
	public class IndexModel : PageModel
	{
		private AppDbContext _context;
		public Product product { get; set; }
		public IndexModel(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> OnGetAsync(long id = 1)
		{
			product = await _context.Products.FindAsync(id);

			if (product == null)
			{
				return RedirectToPage("NotFound");
			}

			return Page();
		}
	}
}
