using Shop.Domain.DTOs.Product;
using Shop.Domain.Models.Enums;
using Shop.Domain.Models.ProductEntity;

namespace Shop.Appliation.Interfaces
{
    public interface IProductService
    {
        #region product
        Task<int> CreateProduct(CreateProductDto product);
        Task<EditProductDto> GetProductById(int productId);
        Task<List<Prodcut>> GetAllProduct();
        Task<EditProductResult> EditProduct(EditProductDto editProduct);
        Task<bool> DeleteProduct(int productId);
        #endregion
    }
}
