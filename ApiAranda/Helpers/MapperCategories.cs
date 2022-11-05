using ApiAranda.Helpers.Interface;
using ApiAranda.Models.DTO;
using ApiAranda.Models.Entities;
using System.Text;

namespace ApiAranda.Helpers
{
    public class MapperCategories : IMapperCategories
    {
        public List<CategoriesDTO> ListCategoriesToDTO(List<Categories> categories)
        {
            List<CategoriesDTO> categoriesDTO = new();
            foreach (var category in categories)
            {
                categoriesDTO.Add(CategoryToDTO(category));
            }

            return categoriesDTO;
        }
        public CategoriesDTO CategoryToDTO(Categories categories)
        {
            return new CategoriesDTO
            {
                Id = categories.Id,
                Name = categories.Name,
            };
        }

        public Categories CategoryDTOToEntity(CategoriesDTO categoriesDTO)
        {
            return new Categories
            {
                Id = categoriesDTO.Id,
                Name = categoriesDTO.Name,
            };
        }
    }
}
