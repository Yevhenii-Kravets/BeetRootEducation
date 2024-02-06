using System.ComponentModel.DataAnnotations;

namespace BREntityFramework.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}
