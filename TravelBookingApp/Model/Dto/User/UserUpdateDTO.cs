﻿using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Model.Dto.User
{
    public class UserUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
