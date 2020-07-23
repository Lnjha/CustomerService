using System.ComponentModel.DataAnnotations;

namespace CustomerService.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(15)]
        public string ContactNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }

    }
}