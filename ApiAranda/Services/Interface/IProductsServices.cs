using ApiAranda.Models.DTO;
using ApiAranda.Models.Entities;

namespace ApiAranda.Services.Interface
{
    public interface IProductsServices
    {
        Task<List<ProductsDTO>> GetProductsList();
        Task<ProductsDTO> GetProductById(Guid Id);
        Task PostProduct(ProductsDTO productsDTO);
        Task PutProduct(ProductsDTO productsDTO);
        Task<bool> DeleteProduct(Guid productId);
    }
}
