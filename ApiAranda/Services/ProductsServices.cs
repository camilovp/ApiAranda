using ApiAranda.Helpers.Interface;
using ApiAranda.Models.DTO;
using ApiAranda.Models.Entities;
using ApiAranda.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace ApiAranda.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapperProducts _mapper;

        public ProductsServices(ApplicationDbContext context, IMapperProducts mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductsDTO>> GetProductsList()
        {
            try
            {
                List<Products> products = await _context.Products.Include(x => x.Category).ToListAsync();
                List<ProductsDTO> productsDTO = _mapper.ListProductsToDTO(products);
                return productsDTO;
            }
            catch (WebException ex)
            {
                throw ex;
            }
            
        }

        public async Task<ProductsDTO> GetProductById(Guid Id)
        {
            try
            {
                var products = await _context.Products.Where(x => x.Id.Equals(Id)).Include(x => x.Category).FirstOrDefaultAsync();
                if (products == null) return new ProductsDTO();
                ProductsDTO productDTO = _mapper.ProductToDTO(products);
                return productDTO;
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }

        public async Task PostProduct(ProductsDTO productsDTO)
        {
            try
            {
                Products products = _mapper.ProductDTOToEntity(productsDTO);
                await _context.Products.AddAsync(products);
                await _context.SaveChangesAsync();
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public async Task PutProduct(ProductsDTO productsDTO)
        {
            try
            {
                Products products = _mapper.ProductDTOToEntity(productsDTO);
                _context.Products.Update(products);
                await _context.SaveChangesAsync();
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            try
            {
                var products = await _context.Products.Where(x => x.Id.Equals(productId)).FirstOrDefaultAsync();
                if (products == null) return false;
                _context.Products.Remove(products);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
    }
}
