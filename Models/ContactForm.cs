using System.ComponentModel.DataAnnotations;
// using System.Diagnostics.Contracts;

namespace netmvc.Models
{
    public class ContactForm
    {
        // Unique identifier for each submission
        public int Id { get; set; }

        // Name is required and cannot be null
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        // Required field for Email, must be a valid email address
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        // Required field for Message
        [Required]
        public string Message {  get; set; }

        // Optional Age field
        public int? Age { get; set; }

        // Optional Contact Number field
        [RegularExpression(@"^\d+$", ErrorMessage = "Contact number must contain only numbers.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Contact number must be between 10 and 15 digits.")]
        public string? ContactNumber { get; set; }
    }
}
