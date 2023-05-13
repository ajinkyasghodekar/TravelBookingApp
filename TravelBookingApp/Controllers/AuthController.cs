using Microsoft.AspNetCore.Mvc;
using System.Net;
using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto.Security;
using TravelBookingApp.Repository.IRepository;

namespace TravelBookingApp.Controllers
{
        [Route("api/TravelBookingAppAuth")]
        [ApiController]
        public class AuthController : Controller
        {
            private readonly IAuthRepository _userRepo;
            protected APIResponse _response;
            public AuthController(IAuthRepository userRepo)
            {
                _userRepo = userRepo;
                this._response = new();
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
            {
                var loginResponse = await _userRepo.Login(model);
                if (loginResponse == null || string.IsNullOrEmpty(loginResponse.Token))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessage.Add("Username or Password incorrect");
                    return BadRequest(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = loginResponse;
                return Ok(_response);
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
            {
                bool ifUserNameUnique = _userRepo.IsUniqueUser(model.Username);
                if (!ifUserNameUnique)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessage.Add("Username already exists");
                    return BadRequest(_response);
                }
                var user = await _userRepo.Register(model);
                if (user == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessage.Add("Error while registering");
                    return BadRequest(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
        }
    }
