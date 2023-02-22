using SimpleEcommerceApp.Models.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleEcommerceApp.Models
{
    [Table("Categories")]
    public class Category : EntityId, IEntityActivable
    {
        [Required]
        public string CategoryName { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
