
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.ViewModels.ProdutCategories
{
    public class CreateProductCategoryViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "نحوه ارسال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string DeliveryType { get; set; }

        //[Required]
        //public bool IsActive { get; set; }
    }
}
