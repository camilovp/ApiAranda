using ApiAranda.Models.DTO;
using ApiAranda.Models.Entities;

namespace ApiAranda.Helpers.Interface
{
    public interface IMapperCategories
    {
        List<CategoriesDTO> ListCategoriesToDTO(List<Categories> categories);
        CategoriesDTO CategoryToDTO(Categories categories);
        Categories CategoryDTOToEntity(CategoriesDTO categoriesDTO);
    }
}
