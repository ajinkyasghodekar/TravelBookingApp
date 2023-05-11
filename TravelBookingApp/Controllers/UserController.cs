using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return Ok(await _db.UsersTable.ToListAsync());
        }

        // Get User by Id [HttpGet]
        [HttpGet("Id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetUsers(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = await _db.UsersTable.FirstOrDefaultAsync(u => u.Id == id);
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
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserCreateDTO userDTO)
        {
            // Custom validation for User's Name
            if (await _db.UsersTable.FirstOrDefaultAsync(u => u.Name.ToLower() == userDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("", "User Name Already Exists");
                return BadRequest(ModelState);
            }
            Users model = new()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Role = userDTO.Role
            };
           await _db.UsersTable.AddAsync(model);
           await _db.SaveChangesAsync();

            return Ok(userDTO);
        }

        // Delete a User [HttpDelete] based on Id
        [HttpDelete("{id:int}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = await _db.UsersTable.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();

            }
            _db.UsersTable.Remove(user);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // Update a User Data [HttpPut] based on id
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO userDTO)
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
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
