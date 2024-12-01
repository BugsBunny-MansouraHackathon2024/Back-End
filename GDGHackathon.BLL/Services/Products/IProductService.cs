using GDGHackathon.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.BLL.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> CreateProductAsync(ProductAddDto productAddDto);
        Task UpdateProductAsync(ProductAddDto productAddDto);
        Task<ProductDto> DeleteProductAsync(int id);


    }
}
