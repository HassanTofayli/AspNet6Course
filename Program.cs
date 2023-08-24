using AspNet6Course.Data;
using AspNet6Course.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
SeedData.SeedDatabase(context);
app.UseHttpsRedirection();
app.UseHsts();
const string BASEURL = "/api/products";
app.MapGet($"{BASEURL}/{{id}}", async (HttpContext context, AppDbContext db) =>
{
    string id = context.Request.RouteValues["id"] as string;
    if (id != null)
    {
        Product product = db.Products.Find(long.Parse(id));
        if (product == null) context.Response.StatusCode = StatusCodes.Status404NotFound;
        else
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize<Product>(product));
        }
    }
});
app.MapGet(BASEURL, (HttpContext context, AppDbContext db) =>
{
    context.Response.ContentType = "application/json";
    context.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<Product>>(db.Products));

});
app.MapPost(BASEURL, async (HttpContext context, AppDbContext db) =>
{
    Product product = await JsonSerializer.DeserializeAsync<Product>(context.Request.Body);
    if (product != null)
    {
        await db.Products.AddAsync(product);
        await db.SaveChangesAsync();
        context.Response.StatusCode = StatusCodes.Status200OK;
    }
});

app.MapGet("/https", async context => { await context.Response.WriteAsync($"Https: {context.Request.IsHttps}"); });

app.MapGet("/", () => "Hello World!");

app.Run();
