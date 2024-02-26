using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ViewModels.Account
{
    public class EditUserProfileViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را واد نمایید")]
        [MaxLength(50, ErrorMessage = "نمی توانید بیشتر از{1} کااکت باشد {0}")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانادگی")]
        [Required(ErrorMessage = "لطفا {0} را واد نمایید")]
        [MaxLength(50, ErrorMessage = "نمی توانید بیشتر از{1} کااکت باشد {0}")]
        public string LastName { get; set; }

        [Display(Name = "شماره تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را واد نمایید")]
        [MaxLength(11, ErrorMessage = "نمی توانید بیشتر از{1} کااکت باشد {0}")]
        public string PhoneNumber { get; set; }
       
        //[Required]
        //[MaxLength(200)]
        //public string Address { get; set; }

        //[Required]
        //[MaxLength(10)]
        //public string PostalCode { get; set; }


    }
}
