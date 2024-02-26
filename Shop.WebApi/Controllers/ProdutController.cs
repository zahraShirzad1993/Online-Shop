using Microsoft.AspNetCore.Mvc;
using Shop.Appliation.Interfaces;
using Shop.Domain.DTOs.Product;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.Enums;
using Shop.Domain.ViewModels.ProdutCategories;

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProdutController : Controller
    {
        #region Constructor
        private readonly IProductService _productService;
        public ProdutController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion


        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _productService.GetAllProduct();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var result = await _productService.GetProductById(id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> CreateProduct(CreateProductDto product)
        {
            var result = await _productService.CreateProduct(product);
            return Ok(result);
        }

        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> EditProduct([FromBody] EditProductDto editProduct)
        {
            var result = await _productService.EditProduct(editProduct);

            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
