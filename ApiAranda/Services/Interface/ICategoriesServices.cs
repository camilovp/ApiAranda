using ApiAranda.Models.DTO;
using System.Threading.Tasks;

namespace ApiAranda.Services.Interface
{
    public interface ICategoriesServices
    {
        Task<List<CategoriesDTO>> GetCategoriesList();
    }
}
