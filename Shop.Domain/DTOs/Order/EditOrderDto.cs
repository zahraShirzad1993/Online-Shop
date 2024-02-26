
using Shop.Domain.DTOs.OrderDetails;
using Shop.Domain.Models.Enums;

namespace Shop.Domain.DTOs.Order
{
    public class EditOrderDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
            public string Description { get; set; }
            public DateTime DeliveryDateTime { get; set; }

            public DiscountType? DiscountType { get; set; }

            public decimal? DiscountAmount { get; set; }
            //[JsonIgnore]
            public List<CreateOrderDetailDto> OrderDetailDto { get; set; }

        
    }
}
