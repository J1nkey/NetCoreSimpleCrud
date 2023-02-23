namespace SimpleEcommerceApp.Models.Products
{
    public class AddProductRequestDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
    }
}
