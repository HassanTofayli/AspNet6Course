using AspNet6Course.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();

var app = builder.Build();

//IResponseFormatter formatter = new TextResponseFormatter();

app.MapGet("/f1", async (HttpContext context, IResponseFormatter formatter) =>
{
    await formatter.Format(context, "Formatter 1");
});

app.MapGet("/f2", async (HttpContext context, IResponseFormatter formatter) =>
{
    await formatter.Format(context, "Formatter 2");
});

app.MapGet("/", () => "Hello World!");

app.Run();
