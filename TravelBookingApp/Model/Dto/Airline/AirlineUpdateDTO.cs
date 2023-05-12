using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Model.Dto.Airline
{
    public class AirlineUpdateDTO
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string AirlineCode { get; set; }

        public string AirlineName { get; set; }
    }

}
