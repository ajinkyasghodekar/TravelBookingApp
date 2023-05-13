using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingApp.Model
{
    public class Airlines
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string AirlineCode { get; set; }

        public string AirlineName { get; set; }
    }
}

