using AspNet6Course.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.Configure<MvcNewtonsoftJsonOptions>(options =>
{
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
}
);

var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();
app.UseHsts();



app.MapGet("/", () => "Hello World!");

app.Run();
