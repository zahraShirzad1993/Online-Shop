using Shop.Appliation.Interfaces;
using Shop.Domain.DTOs.Product;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.Enums;
using Shop.Domain.Models.ProductEntity;

namespace Shop.Appliation.Services
{
    public class ProductService : IProductService
    {
        #region Constructor
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> CreateProduct(CreateProductDto product)
        {
            var newProduct = new Prodcut
            {
                Description = product.Description,
                IsDelete = false,
                Name = product.Name,
                productCategoryId = product.productCategoryId,
                UnitPrice = product.UnitPrice
            };

            await _productRepository.AddProduct(newProduct);
            await _productRepository.SaveChanges();

            return newProduct.Id;
        }
        public async Task<EditProductResult> EditProduct(EditProductDto editProduct)
        {
            var product = await _productRepository.GetProductById(editProduct.ProductId);

            if (product == null) return EditProductResult.NotFound;

            product.productCategoryId = editProduct.productCategoryId;
            product.UnitPrice = editProduct.UnitPrice;
            product.Name = editProduct.Name;
            product.Description = editProduct.Description;
            product.IsDelete = false;

            _productRepository.UpdateProduct(product);

            await _productRepository.SaveChanges();

            return EditProductResult.Success;
        }
        public async Task<List<Prodcut>> GetAllProduct()
        {
            var product = await _productRepository.GetAllProduct();
            if (product != null)
            {
                return product;
            }
            return null;
        }
        public async Task<EditProductDto> GetProductById(int productId)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product != null)
            {
                return new EditProductDto
                {
                    Description = product.Description,
                    Name = product.Name,
                    productCategoryId = product.productCategoryId,
                    UnitPrice = product.UnitPrice
                };
            }
            return null;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            return await _productRepository.DeleteProduct(productId);

        }

        #endregion


    }
}
