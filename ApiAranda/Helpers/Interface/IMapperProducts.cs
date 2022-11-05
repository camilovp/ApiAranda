using ApiAranda.Models.DTO;
using ApiAranda.Models.Entities;

namespace ApiAranda.Helpers.Interface
{
    public interface IMapperProducts
    {
        List<ProductsDTO> ListProductsToDTO(List<Products> products);
        ProductsDTO ProductToDTO(Products product);
        Products ProductDTOToEntity(ProductsDTO productDTO);
    }
}
