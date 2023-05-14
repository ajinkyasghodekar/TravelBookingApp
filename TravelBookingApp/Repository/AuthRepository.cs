using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelBookingApp.Data;
using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto.Security;
using TravelBookingApp.Repository.IRepository;

namespace TravelBookingApp.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly MyAppDb _db;
        private string secretKey;
        public AuthRepository(MyAppDb db, IConfiguration configuration)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string username)
        {
            var user = _db.AuthSecurityTable.FirstOrDefault(x => x.Username == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.AuthSecurityTable.FirstOrDefault(u => u.Username.ToLower() == loginRequestDTO.Username.ToLower() && u.Password == loginRequestDTO.Password);
            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }

            // If user was found then we need to generate a JWT.

            var tokenHandler = new JwtSecurityTokenHandler();

            // Encoding of a key=> we need it in bytes and it is in string.
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.ToString()),
                    new Claim(ClaimTypes.Role, user.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };
            return loginResponseDTO;
        }

        public async Task<AuthSecurity> Register(RegistrationRequestDTO registerationRequestDTO)
        {
            AuthSecurity user = new AuthSecurity()
            {
                Username = registerationRequestDTO.Username,
                Password = registerationRequestDTO.Password,
                Name = registerationRequestDTO.Name,
                Role = registerationRequestDTO.Role
            };

            _db.AuthSecurityTable.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
