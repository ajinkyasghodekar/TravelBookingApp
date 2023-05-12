using AutoMapper;
using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto.Airline;
using TravelBookingApp.Model.Dto.User;

namespace TravelBookingApp
{
    public class AutoMappingConfig: Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<Users, UserDTO>().ReverseMap();
            CreateMap<Users, UserCreateDTO>().ReverseMap();
            CreateMap<Users, UserUpdateDTO>().ReverseMap();

            CreateMap<Airlines, AirlineDTO>().ReverseMap();
            CreateMap<Airlines, AirlineCreateDTO>().ReverseMap();
            CreateMap<Airlines, AirlineUpdateDTO>().ReverseMap();
        }
    }
}
