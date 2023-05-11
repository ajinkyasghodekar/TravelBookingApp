using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto;

namespace TravelBookingApp.Data
{
    public static class UserStore
    {
        public static List<UserDTO> UserList =  new List<UserDTO>
            {
                new UserDTO { Id = 1, Name = "Ajinkya"},
                new UserDTO { Id = 2, Name = "Ajay"},
                new UserDTO { Id = 3, Name = "Sam"}
            };
    }
}
