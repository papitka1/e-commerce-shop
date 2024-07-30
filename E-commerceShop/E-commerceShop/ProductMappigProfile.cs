using AutoMapper;
using E_commerceShop.Models;
using E_commerceShop.ModelsDto;

namespace E_commerceShop
{
    public class ProductMappigProfile : Profile
    {
        public ProductMappigProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<EntityChangeDto, Product>();
                
        }
    }
}
