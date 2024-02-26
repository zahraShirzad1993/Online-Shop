using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.Enums;
using Shop.Domain.ViewModels.ProdutCategories;

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductCategoryController : Controller
    {
        #region Constructor
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        #endregion


        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _productCategoryService.GetAllProductCategory();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetProductCategoryById(int id)
        {
            var result = await _productCategoryService.GetProductCategoryById(id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> CreateProductCategory(CreateProductCategoryViewModel createProductCategory)
        {
            var result = await _productCategoryService.CreateProductCategory(createProductCategory);
            return Ok(result);
        }

        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> EditProductCategory([FromBody] EditProductCategoryViewModel editProductCategory)
        {
            var result = await _productCategoryService.EditProductCategory(editProductCategory);

            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productCategoryService.DeleteProductCategory(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }



}
