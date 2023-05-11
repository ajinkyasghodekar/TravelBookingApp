using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using TravelBookingApp.Data;
using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto;

namespace TravelBookingApp.Controllers
{
    [ApiController]
    [Route("api/TravelBookingApp")]

    public class UserController : ControllerBase
    {
        private readonly MyAppDb _db;
        public UserController(MyAppDb db)
        {
            _db = db;
        }

        // Get all User [HttpGet]
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            return Ok(_db.UsersTable.ToList());
        }

        // Get User by Id [HttpGet]
        [HttpGet("Id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetUsers(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = _db.UsersTable.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Create a User [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> CreateUser([FromBody] UserDTO userDTO)
        {
            // Custom validation for User's Name
            if (_db.UsersTable.FirstOrDefault(u => u.Name.ToLower() == userDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("", "User Name Already Exists");
                return BadRequest(ModelState);
            }

            if (userDTO == null)
            {
                return BadRequest(userDTO);
            }
            if (userDTO.Id < 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Users model = new()
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Role = userDTO.Role
            };
            _db.UsersTable.Add(model);
            _db.SaveChangesAsync();

            return Ok(userDTO);
        }

        // Delete a User [HttpDelete] based on Id
        [HttpDelete("{id:int}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = _db.UsersTable.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();

            }
            _db.UsersTable.Remove(user);
            _db.SaveChanges();
            return NoContent();
        }

        // Update a User Data [HttpPut] based on id
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            if (userDTO == null || id != userDTO.Id)
            {
                return BadRequest();
            }
            Users model = new()
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Role = userDTO.Role
            };
            _db.UsersTable.Update(model);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
