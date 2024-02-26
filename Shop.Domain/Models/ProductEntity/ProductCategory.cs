
using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.ProductEntity
{
    public class ProductCategory : BaseEntity
    {
        #region ProdcutCategory
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        //public ProductType Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string DeliveryType { get; set; }
        //public DeliveryType DeliveryType { get; set; }
        #endregion

        #region relations 
        public ICollection<Prodcut> Products { get; set; }

        #endregion
    }
}
