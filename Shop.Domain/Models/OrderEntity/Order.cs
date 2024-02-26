
using Shop.Domain.Models.Account;
using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.Enums;
using Shop.Domain.Models.OrderEntity;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.Order
{
    public class Order : BaseEntity
    {
        #region Order
        [Required]
        public int UserId { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public bool IsFinaly { get; set; }
        public OrderState OrderState { get; set; }
        public DiscountType? DiscountType { get; set; }

        public decimal? DiscountAmount { get; set; }

        [Required]
        public bool IsActive { get; set; }
        #endregion

        #region relations 
        public User user { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
        #endregion

    }
}
