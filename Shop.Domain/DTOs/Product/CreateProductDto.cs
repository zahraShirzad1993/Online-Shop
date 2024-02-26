namespace Shop.Domain.DTOs.Product
{
    public class CreateProductDto
    {
        public int productCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
