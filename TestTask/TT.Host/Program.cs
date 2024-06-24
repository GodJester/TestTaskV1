using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TT.API.Interfaces;
using TT.API.Services;
using TT.Engine.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestTaskDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("default"),
        b => { b.MigrationsHistoryTable("__EFMMigrationsHistory", "TestTask"); });
});


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestTask API", Version = "v1" });
    c.EnableAnnotations();
});

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductInOrderService, ProductInOrderService>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGenNewtonsoftSupport();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestTask API"); });
app.UseRouting();
app.MapControllers();
app.Run();