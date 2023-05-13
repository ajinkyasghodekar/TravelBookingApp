using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using TravelBookingApp.Data;
using TravelBookingApp.Model;
using TravelBookingApp.Model.Dto.Flight;
using TravelBookingApp.Model.Dto.Journey;

namespace TravelBookingApp.Controllers
{
    [ApiController]
    [Route("api/TravelBookingAppJourney")]
    public class JourneyController : ControllerBase
    {
        private readonly MyAppDb _db;
        private readonly IMapper _mapper;
        public JourneyController(MyAppDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // Get all Journey [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JourneyDTO>>> GetJourney()
        {
            IEnumerable <Journeys> journeyList = await _db.JourneysTable.ToListAsync();
            return Ok(_mapper.Map<List<JourneyDTO>>(journeyList));
        }

        // Get Journey by Id [HttpGet]
        [HttpGet("Id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetJourney(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var journey = await _db.JourneysTable.FirstOrDefaultAsync(u => u.Id == id);
            if (journey == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<JourneyDTO>(journey));
        }

        // Create a Journey [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JourneyDTO>> CreateJourney([FromBody] JourneyCreateDTO journeyCreateDTO)
        {
            // Custom validation for Airline Code
            if (await _db.AirlinesTable.FirstOrDefaultAsync(u => u.AirlineCode.ToLower() == journeyCreateDTO.AirlineCode.ToLower()) == null)
            {
                ModelState.AddModelError("", "Invalid Airline Code");
                return BadRequest(ModelState);
            }
            // Custom validation for Flight Code
            if (await _db.FlightsTable.FirstOrDefaultAsync(u => u.FlightCode.ToLower() == journeyCreateDTO.FlightCode.ToLower()) == null)
            {
                ModelState.AddModelError("", "Invalid Flight Code");
                return BadRequest(ModelState);
            }

            Journeys model = _mapper.Map<Journeys>(journeyCreateDTO);

            await _db.JourneysTable.AddAsync(model);
            await _db.SaveChangesAsync();

            return Ok(journeyCreateDTO);
        }

        // Delete a Journey [HttpDelete] based on Id
        [HttpDelete("{id:int}", Name = "DeleteJourney")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteJourney(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var journey = await _db.JourneysTable.FirstOrDefaultAsync(u => u.Id == id);
            if (journey == null)
            {
                return NotFound();

            }
            _db.JourneysTable.Remove(journey);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // Update a Journey Data [HttpPut] based on id
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateJourney(int id, [FromBody] JourneyUpdateDTO journeyUpdateDTO)
        {
            // Custom validation for Airline Code
            if (await _db.AirlinesTable.FirstOrDefaultAsync(u => u.AirlineCode.ToLower() == journeyUpdateDTO.AirlineCode.ToLower()) == null)
            {
                ModelState.AddModelError("", "Invalid Airline Code");
                return BadRequest(ModelState);
            }
            // Custom validation for Flight Code
            if (await _db.FlightsTable.FirstOrDefaultAsync(u => u.FlightCode.ToLower() == journeyUpdateDTO.FlightCode.ToLower()) == null)
            {
                ModelState.AddModelError("", "Invalid Flight Code");
                return BadRequest(ModelState);
            }

            if (journeyUpdateDTO == null || id != journeyUpdateDTO.Id)
            {
                return BadRequest();
            }
            Journeys model = _mapper.Map<Journeys>(journeyUpdateDTO);

            _db.JourneysTable.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
