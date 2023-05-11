using Microsoft.AspNetCore.Mvc;
using TravelBookingApp.Data;
using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto;

namespace TravelBookingApp.Controllers
{
    [ApiController]
    [Route("api/TravelBookingApp")]

    public class UserController : ControllerBase
    {
        // Get all User [HttpGet]
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            return Ok(UserStore.UserList);
        }

        // Get User by Id [HttpGet]
        [HttpGet("Id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = UserStore.UserList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Create a User [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult <UserDTO> CreateUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest(userDTO);
            }
            if (userDTO.Id < 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            userDTO.Id = UserStore.UserList.OrderByDescending(u => u.Id).FirstOrDefault().Id+1;
            UserStore.UserList.Add(userDTO);
            return Ok(userDTO); 
        }
    }
}
