using AutoMapper;
using E_commerceShop.Data;
using E_commerceShop.Models;
using E_commerceShop.ModelsDto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerceShop.Services
{
    public class ProductServices : IProductServices1
    {
        private readonly ShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductServices(ShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> Getthis()
        {
            var product = _dbContext
                .Products
                .ToList();
            var productDto = _mapper.Map<List<ProductDto>>(product);
            return productDto;
        }

        public ProductDto GetById(int id)
        {
            var products = _dbContext
                .Products
                .FirstOrDefault(p => p.Id == id);
            if (products is null) return null;

            var result = _mapper.Map<ProductDto>(products);
            return result;


        }

        public int CreateProduct(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return product.Id;


        }

        public bool DeleteProduct(int id)
        {
            var products = _dbContext
                .Products
                .FirstOrDefault(p => p.Id == id);
            if (products is null) return false;

            _dbContext .Products.Remove(products);
            _dbContext.SaveChanges();
            return true;
        }
        public bool ChangeProductData(int id ,EntityChangeDto dto)
        {
            var products = _dbContext
                .Products
                .FirstOrDefault(p => p.Id == id);
            if (products is null) return false;

            products.Name = dto.Name;
            products.Quantity = dto.Quantity;
            _dbContext.SaveChanges();
            
            return true;

        }

    }
}
