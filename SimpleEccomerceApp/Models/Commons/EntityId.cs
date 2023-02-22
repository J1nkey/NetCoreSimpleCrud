using System.ComponentModel.DataAnnotations;

namespace SimpleEcommerceApp.Models.Commons
{
    public class EntityId
    {
        [Key]
        public int Id { get; set; }
    }
}
