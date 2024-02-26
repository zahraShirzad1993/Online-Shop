
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.ProductEntity;
using Shop.Infra.Data.Context;

namespace Shop.Infra.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        #region constractor
        private readonly ShopDbContext _context;
        public ProductCategoryRepository(ShopDbContext context)
        {
            _context = context;
        }
        #endregion

                public async Task AddProductCtaegory(ProductCategory productCategory)
        {
            await _context.ProductCategories.AddAsync(productCategory);
        }
        public async Task<List<ProductCategory>> GetAllProductCategory() => await _context.ProductCategories.ToListAsync();
        public async Task<ProductCategory> GetProductCategoryById(int id)
        {
            return await _context.ProductCategories.AsQueryable()
                .SingleOrDefaultAsync(c => c.Id == id);
        }

                public void UpdateProductCtaegory(ProductCategory category)
        {
            _context.Update(category);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteProductCtaegory(int Id)
        {
            var Productcategory = await _context.ProductCategories.AsQueryable()
                .Where(c => c.Id == Id).FirstOrDefaultAsync();

            if (Productcategory != null)
            {
                Productcategory.IsDelete = true;
                _context.ProductCategories.Update(Productcategory);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
