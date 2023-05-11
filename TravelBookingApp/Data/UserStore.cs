using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto;

namespace TravelBookingApp.Data
{
    public static class UserStore
    {
        public static List<UserDTO> UserList =  new List<UserDTO>
            {
                new UserDTO { Id = 1, Name = "Ajinkya", Email="ajinkya@gmail.com", Password = "Ajinkya123", Role="Admin"},
                new UserDTO { Id = 2, Name = "Ajay", Email="ajay@gmail.com", Password = "Ajay123", Role="User"},
                new UserDTO { Id = 3, Name = "Sam", Email="sam@gmail.com", Password = "Sam123", Role="User"}
            };
    }
}
