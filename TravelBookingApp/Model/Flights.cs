using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Model
{
    public class Flights
    {
        internal string flightCode;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required]
        public string FlightCode { get; set; }

        public string FlightName { get; set; }
    }
}

