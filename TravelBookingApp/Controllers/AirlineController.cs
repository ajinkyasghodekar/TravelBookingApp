using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBookingApp.Data;
using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto.Airline;

namespace TravelBookingApp.Controllers
{
    [Route("api/TravelBookingAppAirline")]
    [ApiController]

    public class AirlineController : ControllerBase
    {
        private readonly MyAppDb _db;
        private readonly IMapper _mapper;
        public AirlineController(MyAppDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // Get all Airlines [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirlineDTO>>> GetAirlines()
        {
            IEnumerable<Airlines> airlinesList = await _db.AirlinesTable.ToListAsync();
            return Ok(_mapper.Map<List<AirlineDTO>>(airlinesList));
        }

        // Get Airline by Id [HttpGet]
        [HttpGet("{airlineCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAirline(string airlineCode)
        {
            if (airlineCode == null)
            {
                return BadRequest();
            }
            var airline = await _db.AirlinesTable.FirstOrDefaultAsync(u => u.AirlineCode == airlineCode);
            if (airline == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AirlineDTO>(airline));
        }

        // Create a Airline [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AirlineDTO>> CreateAirline([FromBody] AirlineCreateDTO airlineCreateDTO)
        {
            // Custom validation for Airlines Name
            if (await _db.AirlinesTable.FirstOrDefaultAsync(u => u.AirlineName.ToLower() == airlineCreateDTO.AirlineName.ToLower()) != null)
            {
                ModelState.AddModelError("", "Airline Name Already Exists");
                return BadRequest(ModelState);
            }
            Airlines model = _mapper.Map<Airlines>(airlineCreateDTO);

            await _db.AirlinesTable.AddAsync(model);
            await _db.SaveChangesAsync();

            return Ok(airlineCreateDTO);
        }

        // Delete a Airline [HttpDelete] based on Id
        [HttpDelete("{airlineCode}", Name = "DeleteAirline")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteAirline(string airlineCode)
        {
            if (airlineCode == null)
            {
                return BadRequest();
            }
            var airline = await _db.AirlinesTable.FirstOrDefaultAsync(u => u.AirlineCode == airlineCode);
            if (airline == null)
            {
                return NotFound();
            }
            _db.AirlinesTable.Remove(airline);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // Update a Airline Data [HttpPut] based on id
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAirline(string airlineCode, [FromBody] AirlineUpdateDTO airlineUpdateDTO)
        {
            if (airlineUpdateDTO == null || airlineCode != airlineUpdateDTO.AirlineCode)
            {
                return BadRequest();
            }
            Airlines model = _mapper.Map<Airlines>(airlineUpdateDTO);

            _db.AirlinesTable.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
