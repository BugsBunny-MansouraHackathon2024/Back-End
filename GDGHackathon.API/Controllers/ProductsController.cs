using GDGHackathon.BLL.Dtos;
using GDGHackathon.BLL.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GDGHackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
       

        [HttpGet()] // Get : BaseUrl/api/Products/brands
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        

        [HttpGet("{id}")] // Get : BaseUrl/api/Products/{id}
        public async Task<IActionResult> GetProductById(int? id)
        {
            if (id == null)
                return BadRequest("Invalid Id !!!!!");

            var result = await _productService.GetProductById(id.Value);

            if (result == null)
                return NotFound($"The Product With Id: {id} Not Found");

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductAddDto productAddDto)
        {
            if (productAddDto == null)
            {
                return BadRequest("Product data is null.");
            }

            // Optionally, validate the model (if you have custom validation logic)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Use your service layer to create the product
            _productService.CreateProductAsync(productAddDto);


            // Return 201 Created with the location of the new resource (you can modify the URL to suit your API design)
            return Created();
        }

    }
}
