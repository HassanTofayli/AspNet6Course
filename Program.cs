using AspNet6Course.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();
app.UseHsts();

//app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();
app.UseStaticFiles();
app.MapRazorPages();

app.Run();
