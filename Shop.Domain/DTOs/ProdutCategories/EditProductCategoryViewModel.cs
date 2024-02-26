using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.ViewModels.ProdutCategories
{
    public class EditProductCategoryViewModel : CreateProductCategoryViewModel
    {
        public int ProductCategoryId { get; set; }
        public string Title { get; set; }
        public string DeliveryType { get; set; }
    }
}
