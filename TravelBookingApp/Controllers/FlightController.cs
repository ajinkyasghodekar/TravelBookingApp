using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using TravelBookingApp.Data;
using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto.Flight;

namespace TravelBookingApp.Controllers
{
    [Route("api/TravelBookingAppFlight")]
    [ApiController]

    public class FlightController : ControllerBase
    {
        private readonly MyAppDb _db;
        private readonly IMapper _mapper;
        public FlightController(MyAppDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // Get all Flights [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDTO>>> GetFlights()
        {
            IEnumerable<Flights> flightsList = await _db.FlightsTable.ToListAsync();
            return Ok(_mapper.Map<List<FlightDTO>>(flightsList));
        }

        // Get Flight by Id [HttpGet]
        [HttpGet("{flightCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetFlight(string flightCode)
        {
            if (flightCode == null)
            {
                return BadRequest();
            }
            var flight = await _db.FlightsTable.FirstOrDefaultAsync(u => u.FlightCode == flightCode);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<FlightDTO>(flight));
        }

        // Create a Flight [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FlightDTO>> CreateFlight([FromBody] FlightCreateDTO flightCreateDTO)
        {
            // Custom validation for Flight Name
            if (await _db.FlightsTable.FirstOrDefaultAsync(u => u.FlightName.ToLower() == flightCreateDTO.FlightName.ToLower()) != null)
            {
                ModelState.AddModelError("", "Flight Name Already Exists");
                return BadRequest(ModelState);
            }

            // Custom validation for Airline Code
            if (await _db.AirlinesTable.FirstOrDefaultAsync(u => u.AirlineCode.ToLower() == flightCreateDTO.AirlineCode.ToLower()) == null)
            {
                ModelState.AddModelError("", "Invalid Airline Code");
                return BadRequest(ModelState);
            }

            Flights model = _mapper.Map<Flights>(flightCreateDTO);

            await _db.FlightsTable.AddAsync(model);
            await _db.SaveChangesAsync();

            return Ok(flightCreateDTO);
        }

        // Delete a Flight [HttpDelete] based on Id
        [HttpDelete("{flightCode}", Name = "DeleteFlight")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteFlight(string flightCode)
        {
            if (flightCode == null)
            {
                return BadRequest();
            }
            var flight = await _db.FlightsTable.FirstOrDefaultAsync(u => u.FlightCode == flightCode);
            if (flight == null)
            {
                return NotFound();
            }
            _db.FlightsTable.Remove(flight);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // Update a Flight Data [HttpPut] based on id
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateFlight(string flightCode, [FromBody] FlightUpdateDTO flightUpdateDTO)
        {
            // Custom validation for Airline Code
            if (await _db.AirlinesTable.FirstOrDefaultAsync(u => u.AirlineCode.ToLower() == flightUpdateDTO.AirlineCode.ToLower()) == null)
            {
                ModelState.AddModelError("", "Invalid Airline Code");
                return BadRequest(ModelState);
            }

            if (flightUpdateDTO == null || flightCode != flightUpdateDTO.FlightCode)
            {
                return BadRequest();
            }
            Flights model = _mapper.Map<Flights>(flightUpdateDTO);

            _db.FlightsTable.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
