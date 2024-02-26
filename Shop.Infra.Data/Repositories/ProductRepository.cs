
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.ProductEntity;
using Shop.Infra.Data.Context;

namespace Shop.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region constractor
        private readonly ShopDbContext _context;
        public ProductRepository(ShopDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Prodcut product)
        {
            await _context.prodcuts.AddAsync(product);
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            var Product = await _context.prodcuts.AsQueryable()
                .Where(c => c.Id == Id).FirstOrDefaultAsync();

            if (Product != null)
            {
                Product.IsDelete = true;
                _context.prodcuts.Update(Product);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Prodcut>> GetAllProduct() => await _context.prodcuts.ToListAsync();

        public async Task<List<Prodcut>> GetProductsAsync(List<int> produtIds) => await _context.prodcuts.Where(a => produtIds.Contains(a.Id)).ToListAsync();
        public async Task<Prodcut> GetProductById(int id)
        {
            var result= await _context.prodcuts.AsQueryable()
               .SingleOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateProduct(Prodcut product)
        {
            _context.Update(product);
        }
        #endregion
    }
}
