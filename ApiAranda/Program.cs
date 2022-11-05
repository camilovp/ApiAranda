using ApiAranda;
using ApiAranda.Helpers;
using ApiAranda.Helpers.Interface;
using ApiAranda.Services;
using ApiAranda.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("defaultConnection")));

builder.Services.AddScoped<IProductsServices, ProductsServices>();
builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();

//Mapper

builder.Services.AddScoped<IMapperProducts, MapperProducts>();
builder.Services.AddScoped<IMapperCategories, MapperCategories>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(options =>
{
    options.WithOrigins("http://127.0.0.1:5173");
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
