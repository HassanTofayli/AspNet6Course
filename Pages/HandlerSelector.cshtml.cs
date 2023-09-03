using AspNet6Course.Data;
using AspNet6Course.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNet6Course.Pages
{
	public class HandlerSelectorModel : PageModel
	{
		private AppDbContext _context;
		public Product product;


		public HandlerSelectorModel(AppDbContext context)
		{
			_context = context;
		}

		public async Task OnGetAsync(long id = 1)
		{
			product = await _context.Products.FindAsync(id);
		}

		public async Task OnGetCatAsync(long id = 1)
		{
			product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
		}
	}
}
