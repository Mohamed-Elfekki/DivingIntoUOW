using DivingIntoUOW.Core.Models;
using DivingIntoUOW.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DivingIntoUOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var productDetailsList = await _productService.GetAllProducts();
            if (productDetailsList == null)
            {
                return NotFound();
            }
            return Ok(productDetailsList);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var productDetails = await _productService.GetProductById(productId);

            if (productDetails != null)
            {
                return Ok(productDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDetails productDetails)
        {
            var isCreated = await _productService.CreateProduct(productDetails);

            if (isCreated)
            {
                return Ok(isCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("Id")]
        public async Task<IActionResult> UpdateProduct(ProductDetails productDetails)
        {
            if (productDetails != null)
            {
                var isCreated = await _productService.UpdateProduct(productDetails);
                if (isCreated)
                {
                    return Ok(isCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var isCreated = await _productService.DeleteProduct(productId);

            if (isCreated)
            {
                return Ok(isCreated);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
