using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.Enums;
using Shop.Domain.Models.Order;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.Account
{
    public class User : BaseEntity
    {
       
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(6)]
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(4)]
        public string MobileActiveCode { get; set; }

        public bool IsMobileActive { get; set; }

        public UserGender UserGender { get; set; }


        #region relations
        public ICollection<Order.Order> OrderFactors { get; set; }
        #endregion
    }
}

