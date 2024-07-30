using E_commerceShop.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerceShop.Data
{
    public class ProductSeeder
    {
        private readonly ShopDbContext _dbContext;
        public ProductSeeder(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Products.Any())
                {
                    var products = GetProducts();
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "Iphone 13 mini",
                    
                    Quantity = 1,

                    
                },
                new Product()
                {
                    Name = "Motorola",
                    Quantity = 2,
                }

            };

            return products;

        }
    }
}
