
using Shop.Domain.Models.ProductEntity;

namespace Shop.Domain.Interfaces
{
    public interface IProductCategoryRepository
    {

        Task AddProductCtaegory(ProductCategory productCategory);
        Task<ProductCategory> GetProductCategoryById(int id);
        Task<List<ProductCategory>> GetAllProductCategory();
        void UpdateProductCtaegory(ProductCategory category);
        Task<bool> DeleteProductCtaegory(int Id);
        Task SaveChanges();
    }
}
