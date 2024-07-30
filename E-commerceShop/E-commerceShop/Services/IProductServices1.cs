using E_commerceShop.ModelsDto;

namespace E_commerceShop.Services
{
    public interface IProductServices1
    {
        bool ChangeProductData(int id, EntityChangeDto dto);
        int CreateProduct(CreateProductDto dto);
        bool DeleteProduct(int id);
        ProductDto GetById(int id);
        IEnumerable<ProductDto> Getthis();
    }
}