using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Model.Dto.Journey
{
    public class JourneyUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]*$", ErrorMessage = "FlightCode must be an alphanumeric value.")]
        public string FlightCode { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]*$", ErrorMessage = "FlightCode must be an alphanumeric value.")]
        public string AirlineCode { get; set; }

        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime TravelDate { get; set; }
        public int NumberOfPassengers { get; set; }
    }

}
