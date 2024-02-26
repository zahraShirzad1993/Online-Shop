using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.ProductEntity;

namespace Shop.Domain.Models.OrderEntity
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public int OrderQty { get; set; }//tedad
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }

        #region Relations

        public ICollection<Prodcut> Prodcut { get; set; }
        public Order.Order Order { get; set; }
        #endregion

    }
}
