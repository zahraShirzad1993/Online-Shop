using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.Enums
{
    public enum OrderState
    {
        [Display(Name = "درخواست شده")]
        Requested,
        [Display(Name = "در حال بررسی")]
        Processing,
        [Display(Name = "ارسال شده")]
        Sent,
        [Display(Name = "لغو شده")]
        Cancel
    }
}
