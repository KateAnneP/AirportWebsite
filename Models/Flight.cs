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

        [Display(Name = "Data i godzina wylotu/przylotu")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DateAndTime { get; set; }
        
        [ForeignKey("StatusID")]
        public int? StatusID { get; set; } /*klucz obcy do Status*/

        [ForeignKey("TerminalID")]
        public int? TerminalID { get; set; } /*klucz obcy do Terminal*/

        [ForeignKey("AircraftID")]
        public int? AircraftID { get; set; }     /*klucz obcy do Aircraft*/

        [ForeignKey("StaffID")]
        public int? StaffID { get; set; }    /*klucz obcy do Staff*/

        [ForeignKey("PassengerID")]
        public int? PassengerID { get; set; }    /*klucz obcy do Passengers*/

        [ForeignKey("DestinationID")]
        public int? DestinationID { get; set; }  /*klucz obcy do Destination*/


    }
}
