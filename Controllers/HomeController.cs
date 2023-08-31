using AspNet6Course.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNet6Course.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(long id)
        {
            return View(await _db.Products.FindAsync(id));
        }
        public async Task<IActionResult> List()
        {
            return View(await _db.Products.ToListAsync());
        }
    }
}
