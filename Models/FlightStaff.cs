using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt.Models
{
    public class FlightStaff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightStaffID { get; set; }

        public int FlightId { get; set; }
        public Flight? Flight { get; set; }

        public int StaffId { get; set; }
        public Staff? Staff { get; set; }
    }
}
