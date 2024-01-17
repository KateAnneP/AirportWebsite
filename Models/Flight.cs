using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt.Models
{
    [Table("Flights")]
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]                                                                                                                                                                       
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        [Display(Name = "Numer lotu")]
        public string Number { get; set; }    /*numer lotu*/

        [Required]
        [StringLength(50)]
        [Display(Name = "Linia lotnicza")]
        public string Line { get; set; }
        public DateTime DateAndTime { get; set; }
        public int StatusID { get; set; } /*klucz obcy do Status*/
        public int TerminalID { get; set; } /*klucz obcy do Terminal*/
        public int AircraftID { get; set; }     /*klucz obcy do Aircraft*/
        public int StaffID { get; set; }    /*klucz obcy do Staff*/
        public int PassengerID { get; set; }    /*klucz obcy do Passengers*/
        public int DestinationID { get; set; }  /*klucz obcy do Destination*/


    }
}
