using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Model
{
    public class Journeys
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }


        [ForeignKey("Flights")]
        public string FlightCode { get; set; }

        [ForeignKey("Airlines")]
        public string AirlineCode { get; set; }

        public Flights Flights { get; set; }
        public Airlines Airlines { get; set; }


        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime TravelDate { get; set; }
        public int NumberOfPassengers { get; set;}

    }
}

