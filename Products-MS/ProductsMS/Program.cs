using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductsMS.Models.Domain;
using ProductsMS.Repositories.Abstract;
using ProductsMS.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>(); //resoliving our all dependances
builder.Services.AddTransient<IProductRepository, ProductRepository>(); //resoliving our all dependances

var app = builder.Build();

app.UseHttpsRedirection();

//in developing cases
app.UseCors(
     options =>
     options.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
