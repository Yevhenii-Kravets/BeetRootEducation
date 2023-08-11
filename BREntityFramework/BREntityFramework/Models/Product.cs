using System.ComponentModel.DataAnnotations;

namespace BREntityFramework.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}
