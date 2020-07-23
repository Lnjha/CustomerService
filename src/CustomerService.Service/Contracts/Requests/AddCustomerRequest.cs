using System.ComponentModel.DataAnnotations;

namespace CustomerService.Service.DTO
{
    public class AddCustomerRequest
    {
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
