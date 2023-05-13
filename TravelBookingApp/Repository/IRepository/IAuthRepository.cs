using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto.Security;

namespace TravelBookingApp.Repository.IRepository
{
    public interface IAuthRepository
    {
        bool IsUniqueUser(string username);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<AuthSecurity> Register(RegistrationRequestDTO registerationRequestDTO);
    }
}
