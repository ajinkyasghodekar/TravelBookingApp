using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Model.Dto.User
{
    public class UserCreateDTO
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
