using System.ComponentModel.DataAnnotations;

namespace BREntityFramework.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
