using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Model.Dto.Airline
{
    public class AirlineDTO
    {


        [Required]
        public string AirlineCode { get; set; }

        public string AirlineName { get; set; }
    }
}
