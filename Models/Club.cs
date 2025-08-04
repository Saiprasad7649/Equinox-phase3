using System.ComponentModel.DataAnnotations;

namespace Equinox.Models
{
    public class Club
    {
        public int ClubId { get; set; }

        [Required(ErrorMessage = "Club name is required.")]
        [StringLength(50, ErrorMessage = "Club name cannot exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Club name can only contain letters, numbers, and spaces.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
