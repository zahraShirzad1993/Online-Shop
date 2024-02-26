
using Shop.Domain.DTOs.OrderDetails;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.Enums;
using Shop.Domain.Models.OrderEntity;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.DTOs.Order
{
    public class OrderDto
    {
       
        public int UserId { get; set; }

        public string Description { get; set; }
      
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public bool IsFinaly { get; set; }
        public OrderState OrderState { get; set; }
        public DiscountType? DiscountType { get; set; }

        public decimal? DiscountAmount { get; set; }

        public bool IsActive { get; set; }

        public User user { get; set; }
        public List<EditOrderDetailDto> OrderDetail { get; set; }
    }
}
