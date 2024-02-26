using Shop.Domain.Models.ProductEntity;

namespace Shop.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task AddProduct(Prodcut product);
        Task<Prodcut> GetProductById(int id);
        Task<List<Prodcut>> GetAllProduct();
        Task<List<Prodcut>> GetProductsAsync(List<int> produtIds);
        void UpdateProduct(Prodcut product);
        Task<bool> DeleteProduct(int Id);
        Task SaveChanges();
    }
}
