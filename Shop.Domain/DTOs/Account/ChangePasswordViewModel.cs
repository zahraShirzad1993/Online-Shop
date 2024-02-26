
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "کلمه عبور قبلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(6, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string CurrentPassword { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(6, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(6, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Compare("Password", ErrorMessage = "مغایرت در تکرار کلمه عبور")]
        public string ConfirmNewPassword { get; set; }
    }
}
