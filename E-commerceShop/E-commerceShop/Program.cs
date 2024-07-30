using E_commerceShop.Data;
using E_commerceShop.Services;
using Microsoft.OpenApi.Writers;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ShopDbContext>();
        builder.Services.AddScoped<ProductSeeder>();
        builder.Services.AddScoped<IProductServices1, ProductServices>();
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


        var app = builder.Build();

        var scope = app.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<ProductSeeder>();
        seeder.seed();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {

            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}