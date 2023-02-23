using SimpleEcommerceApp.Models.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleEcommerceApp.Models.Products
{
    [Table("Products")]
    public class Product : EntityId, IEntityActivable
    {
        [Required(ErrorMessage = "The product name invalid")]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 255, MinimumLength = 5, ErrorMessage = "The product name must have length from 5 to 255")]
        public string ProductName { get; set; }
        [DataType(DataType.Text)]
        [StringLength(255)]
        public string Description { get; set; }
        [DataType(DataType.Text)]
        [StringLength(255)]
        public string Details { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
