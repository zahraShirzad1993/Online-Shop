
namespace Shop.Domain.DTOs.OrderDetails
{
    public class CreateOrderDetailDto
    {
        public int ProductId { get; set; }
        public int OrderQty { get; set; }//tedad
        public bool Benefit { get; set; }
    }
}
