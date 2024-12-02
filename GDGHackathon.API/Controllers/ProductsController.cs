using GDGHackathon.BLL.Dtos;
using GDGHackathon.DAL.Entities;
using GDGHackathon.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GDGHackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _unitOfWork.Product.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/products/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _unitOfWork.Product.GetByIdAsync(id);
                if (product == null)
                    return NotFound($"Product with ID {id} not found.");
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/products
        [Authorize(Roles = "Farmer")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            // Get the logged-in user's ID
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized("User is not authenticated.");

            if (productDto == null)
                    return BadRequest("Product is null.");

            var farmer = await _unitOfWork.UserApp.GetByIdAsync(userId );

            var product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    HarvestDate = productDto.HarvestDate,
                    Quantity = productDto.Quantity,
                    ImageUrl = productDto.ImageUrl,
                    FarmerId = farmer.Id,
                };
                await _unitOfWork.Product.AddAsync(product);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, new {message="successfully created"});
            
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            try
            {
          
                var existingProduct = await _unitOfWork.Product.GetByIdAsync(id);
                if (existingProduct == null)
                    return NotFound($"Product with ID {id} not found.");
               
                    existingProduct.Name = productUpdateDto.Name;
                    existingProduct.Price = productUpdateDto.Price;
                    existingProduct.HarvestDate = productUpdateDto.HarvestDate;
                    existingProduct.Quantity = productUpdateDto.Quantity;
                    existingProduct.ImageUrl = productUpdateDto.ImageUrl;
                    

                await _unitOfWork.Product.UpdateAsync(existingProduct);
                return NoContent(); // 204 No Content indicates successful update
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _unitOfWork.Product.GetByIdAsync(id);
                if (product == null)
                    return NotFound($"Product with ID {id} not found.");

                await _unitOfWork.Product.DeleteAsync(product);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
