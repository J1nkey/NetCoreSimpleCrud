namespace SimpleEcommerceApp.Models.Products
{
    public class UpdateProductRequestDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
