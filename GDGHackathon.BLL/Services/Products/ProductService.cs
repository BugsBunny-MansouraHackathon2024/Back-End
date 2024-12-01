using GDGHackathon.BLL.Dtos;
using GDGHackathon.DAL.Data;
using GDGHackathon.DAL.Entities;
using GDGHackathon.DAL.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.BLL.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ProductDto> CreateProductAsync(ProductAddDto productAddDto)
        {
            

            var product = new Product
            {
                Name = productAddDto.Name,
                HarvestDate = productAddDto.HarvestDate,
                PricePerUnit = productAddDto.Price,
                Description = productAddDto.Description,
                ImageUrl = productAddDto.ImageUrl
               
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                PricePerUnit = product.PricePerUnit,
                Description = product.Description,
                HarvestDate = product.HarvestDate,
                ImageUrl = product.ImageUrl,
            };
             
            return productDto;
        }

         
        public Task<ProductDto> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            return await _context.Products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                HarvestDate = p.HarvestDate,
                PricePerUnit = p.PricePerUnit,
                Description = p.Description,
                ImageUrl=$"https://localhost:7019/"+"Images/Products/"+ p.ImageUrl+".jpg"
            })
            .ToListAsync();
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
              
                 Id = product.Id,
                Name = product.Name,
                HarvestDate = product.HarvestDate,
                PricePerUnit = product.PricePerUnit,
                Description = product.Description,
                ImageUrl = $"https://localhost:7019/" + "Images/Products/" + product.ImageUrl + ".jpg"
            };
        }

        public Task UpdateProductAsync(ProductAddDto productAddDto)
        {
            throw new NotImplementedException();
        }
    }

}
