
using System.Linq.Expressions;

namespace Shop.Domain.DTOs.Product
{
    public class EditProductDto
    {
        public int ProductId { get; set; }
        public int productCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
