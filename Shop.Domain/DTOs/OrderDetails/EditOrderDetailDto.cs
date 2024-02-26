
using Shop.Domain.DTOs.Product;
using Shop.Domain.Models.ProductEntity;

namespace Shop.Domain.DTOs.OrderDetails
{
    public class EditOrderDetailDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderQty { get; set; }//tedad
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }

        #region Relations

        public List<EditProductDto> Prodcut { get; set; }
        #endregion
    }
}
