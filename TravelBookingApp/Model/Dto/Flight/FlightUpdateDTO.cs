using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Model.Dto.Flight
{
    public class FlightUpdateDTO
    {

        [Required]
        public string FlightCode { get; set; }

        public string FlightName { get; set; }
    }

}
