using ApiAranda.Helpers.Interface;
using ApiAranda.Models.DTO;
using ApiAranda.Models.Entities;
using System.Text;

namespace ApiAranda.Helpers
{
    public class MapperProducts : IMapperProducts
    {
        public List<ProductsDTO> ListProductsToDTO(List<Products> products)
        {
            List<ProductsDTO> productsDTO = new();
            foreach (var product in products)
            {
                productsDTO.Add(ProductToDTO(product));
            }

            return productsDTO;
        }

        public ProductsDTO ProductToDTO(Products product)
        {
            return new ProductsDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = Encoding.Default.GetString(product.Image),
                IdCategory = product.IdCategory,
                NameCategory = product.Category.Name
            };
        }

        public Products ProductDTOToEntity(ProductsDTO productDTO)
        {
            return new Products
            {
                Id = productDTO.Id != null? productDTO.Id.Value : Guid.NewGuid(),
                Name = productDTO.Name,
                Description = productDTO.Description,
                Image = Encoding.Default.GetBytes(productDTO.Image),
                IdCategory = productDTO.IdCategory
            };
        }
    }
}
