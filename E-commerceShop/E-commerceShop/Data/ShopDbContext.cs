using E_commerceShop.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerceShop.Data
{
    public class ShopDbContext: DbContext
    { 
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=EshopDb;Trusted_Connection=True;";
        public DbSet<Product> Products { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            modelBuilder.Entity<Product>()
                .Property(b => b.Quantity)
                .IsRequired();
            
            
                
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
