using AutoMapper;
using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto;

namespace TravelBookingApp
{
    public class AutoMappingConfig: Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<Users, UserDTO>().ReverseMap();
            CreateMap<Users, UserCreateDTO>().ReverseMap();
            CreateMap<Users, UserUpdateDTO>().ReverseMap();
        }
    }
}
