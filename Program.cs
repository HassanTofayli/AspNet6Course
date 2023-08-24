var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(5);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseSession();

app.MapGet("/session", async context =>
{
    int counter = (context.Session.GetInt32("counter") ?? 0) + 1;
    context.Session.SetInt32("counter", counter);
    context.Session.CommitAsync();
    await context.Response.WriteAsync($"Res from session: {counter}");
});

app.MapGet("/cookie", async context =>
{
    int counter = int.Parse(context.Request.Cookies["counter"] ?? "0") + 1;
    context.Response.Cookies.Append(
        "counter",
        counter.ToString(),
        new CookieOptions
        {
            MaxAge = TimeSpan.FromMinutes(2)
        }

        );
    await context.Response.WriteAsync($"Cookie Content: {counter}");
});



app.MapGet("/", () => "Hello World!");

app.Run();
