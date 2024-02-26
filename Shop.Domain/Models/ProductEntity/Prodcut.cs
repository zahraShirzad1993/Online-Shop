
using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.OrderEntity;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Shop.Domain.Models.ProductEntity
{
    public class Prodcut : BaseEntity
    {
        #region Prodcut
        [Required]
        public int productCategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

        public decimal benefitPrcie { get; set; }

        #endregion

        #region relations 
        public ProductCategory ProductCategory { get; set; }

        #endregion





    }
}
