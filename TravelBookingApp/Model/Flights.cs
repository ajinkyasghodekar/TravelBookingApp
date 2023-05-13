using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Model
{
    public class Flights
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FlightCode { get; set; }

        [ForeignKey("Airlines")]
        public string AirlineCode { get; set; }
        public Airlines Airlines { get; set; }
        public string FlightName { get; set; }
    }
}

