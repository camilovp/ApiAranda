using ApiAranda.Models.DTO;
using ApiAranda.Models.Entities;
using ApiAranda.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiAranda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsServices _productServices;
        public ProductController(IProductsServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductsDTO>>> GetProductsList()
        {
            try
            {
                List<ProductsDTO> products = await _productServices.GetProductsList();

                if (products == null || products.Count <= 0) return NoContent();
                return Ok(products);
            }
            catch (WebException ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> PostProduct([FromBody] ProductsDTO productsDTO)
        {
            try
            {
                await _productServices.PostProduct(productsDTO);
                return Ok();
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(ex.Message);
            }
            catch (WebException ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> PutProduct([FromBody] ProductsDTO productsDTO)
        {
            try
            {
                await _productServices.PutProduct(productsDTO);
                return Ok();
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(ex.Message);
            }
            catch (WebException ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct([FromQuery(Name = "productId")] Guid productId)
        {
            try
            {
                await _productServices.DeleteProduct(productId);
                return Ok();
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(ex.Message);
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NoContent)
            {
                return NoContent();
            }
            catch (WebException ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
