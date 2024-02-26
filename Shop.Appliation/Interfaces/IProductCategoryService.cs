using Shop.Domain.Models.Enums;
using Shop.Domain.Models.ProductEntity;
using Shop.Domain.ViewModels.ProdutCategories;

namespace Shop.Domain.Interfaces
{
    public interface IProductCategoryService
    {
        #region productCategory
        Task<int> CreateProductCategory(CreateProductCategoryViewModel createCategory);
        Task<EditProductCategoryViewModel> GetProductCategoryById(int categoryId);
        Task<List<ProductCategory>> GetAllProductCategory();
        Task<EditProductCategoryResult> EditProductCategory(EditProductCategoryViewModel editProductCategory);
        Task<bool> DeleteProductCategory(int productId);

        #endregion
    }
}
