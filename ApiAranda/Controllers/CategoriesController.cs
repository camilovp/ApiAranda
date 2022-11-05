using ApiAranda.Helpers.Interface;
using ApiAranda.Models.DTO;
using ApiAranda.Services;
using ApiAranda.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiAranda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices _categoriesServices;
        public CategoriesController(ICategoriesServices categoriesServices)
        {
            _categoriesServices = categoriesServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriesDTO>>> GetCategoriesList()
        {
            try
            {
                List<CategoriesDTO> categoriesDTO = await _categoriesServices.GetCategoriesList();

                if (categoriesDTO == null || categoriesDTO.Count <= 0) return NoContent();
                return Ok(categoriesDTO);
            }
            catch (WebException ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
