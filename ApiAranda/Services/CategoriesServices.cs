using ApiAranda.Helpers.Interface;
using ApiAranda.Models.DTO;
using ApiAranda.Models.Entities;
using ApiAranda.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiAranda.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapperCategories _mapper;

        public CategoriesServices(ApplicationDbContext context, IMapperCategories mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoriesDTO>> GetCategoriesList()
        {
            try
            {
                List<Categories> categories = await _context.Categories.ToListAsync();
                List<CategoriesDTO> categoriesDTO = _mapper.ListCategoriesToDTO(categories);
                return categoriesDTO;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
    }
}
