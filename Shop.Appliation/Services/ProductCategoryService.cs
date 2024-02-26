using Shop.Domain.Interfaces;
using Shop.Domain.Models.Enums;
using Shop.Domain.Models.ProductEntity;
using Shop.Domain.ViewModels.ProdutCategories;

namespace Shop.Appliation.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        #region Constructor
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        #endregion


        #region product categories
        public async Task<int> CreateProductCategory(CreateProductCategoryViewModel createCategory)
        {
            var newCategory = new ProductCategory
            {

                DeliveryType = createCategory.DeliveryType,
                Title = createCategory.Title,
                IsDelete = false
            };

            await _productCategoryRepository.AddProductCtaegory(newCategory);
            await _productCategoryRepository.SaveChanges();

            return newCategory.Id;
        }

        public async Task<EditProductCategoryViewModel> GetProductCategoryById(int categoryId)
        {
            var productcategory = await _productCategoryRepository.GetProductCategoryById(categoryId);
            if (productcategory != null)
            {
                return new EditProductCategoryViewModel
                {
                    ProductCategoryId = productcategory.Id,
                    DeliveryType = productcategory.DeliveryType,
                    Title = productcategory.Title
                };
            }
            return null;
        }

        public async Task<List<ProductCategory>> GetAllProductCategory()
        {
            var productcategory = await _productCategoryRepository.GetAllProductCategory();
            if (productcategory != null)
            {
                return productcategory;
            }
            return null;
        }

        public async Task<EditProductCategoryResult> EditProductCategory(EditProductCategoryViewModel editProductCategory)
        {
            var productcategory = await _productCategoryRepository.GetProductCategoryById(editProductCategory.ProductCategoryId);

            if (productcategory == null) return EditProductCategoryResult.NotFound;

            productcategory.Title = editProductCategory.Title;
            productcategory.DeliveryType = editProductCategory.DeliveryType;
            productcategory.IsDelete = false;

            _productCategoryRepository.UpdateProductCtaegory(productcategory);

            await _productCategoryRepository.SaveChanges();

            return EditProductCategoryResult.Success;
        }


        public async Task<bool> DeleteProductCategory(int productcategoryId)
        {
            return await _productCategoryRepository.DeleteProductCtaegory(productcategoryId);

        }

        #endregion
    }
}
