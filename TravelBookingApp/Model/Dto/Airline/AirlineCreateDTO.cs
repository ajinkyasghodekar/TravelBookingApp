using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Model.Dto.Airline
{
    public class AirlineCreateDTO
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]*$", ErrorMessage = "AirlineCode must be an alphanumeric value.")]
        public string AirlineCode { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "AirlineName must contain only alphabetical characters.")]
        public string AirlineName { get; set; }
    }
}

