using System.ComponentModel.DataAnnotations;

namespace TravelBookingApp.Model.Dto.Journey
{
    public class JourneyDTO
    {

        public int Id { get; set; }
        public string FlightCode { get; set; }
        public string AirlineCode { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime TravelDate { get; set; }
        public int NumberOfPassengers { get; set; }
    }
}
