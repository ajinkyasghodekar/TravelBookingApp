using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Model.Dto.Flight
{
    public class FlightDTO
    {

        [Required]
        public string FlightCode { get; set; }

        public string FlightName { get; set; }
    }
}
