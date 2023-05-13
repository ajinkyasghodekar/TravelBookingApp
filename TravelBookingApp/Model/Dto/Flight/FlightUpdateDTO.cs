using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Model.Dto.Flight
{
    public class FlightUpdateDTO
    {

        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]*$", ErrorMessage = "FlightCode must be an alphanumeric value.")]
        public string FlightCode { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]*$", ErrorMessage = "FlightCode must be an alphanumeric value.")]
        public string AirlineCode { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "FlightName must contain only alphabetical characters.")]
        public string FlightName { get; set; }
    }

}
