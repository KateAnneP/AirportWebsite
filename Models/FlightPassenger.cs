using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt.Models
{
    [Table("FlightPassenger")]
    public class FlightPassenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightPassengerID { get; set; }

        public int PassengerId { get; set; }
        public Passenger? Passenger { get; set; }

        public int FlightId { get; set; }
        public Flight? Flight { get; set; }
    }
}
