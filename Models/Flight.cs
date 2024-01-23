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

        [Display(Name = "Data i godzina wylotu/przylotu")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DateAndTime { get; set; }

        [ForeignKey("LineID")]
        public int? LineID { get; set; }

        [ForeignKey("StatusID")]
        public int? StatusID { get; set; } /*klucz obcy do Status*/

        [ForeignKey("TerminalID")]
        public int? TerminalID { get; set; } /*klucz obcy do Terminal*/

        [ForeignKey("PlaneID")]
        public int? PlaneID { get; set; }     /*klucz obcy do Plane*/

        /*[ForeignKey("StaffID")]
        public int? StaffID { get; set; }*/    /*klucz obcy do Staff*/

        /*[ForeignKey("PassengerID")]
        public int? PassengerID { get; set; } */   /*klucz obcy do Passengers*/

        [ForeignKey("DestinationID")]
        public int? DestinationID { get; set; }  /*klucz obcy do Destination*/

        [Display(Name = "Status lotu")]
        public virtual Line Line { get; set; }

        [Display(Name = "Status lotu")]
        public virtual Status Status { get; set; }

        [Display(Name = "Terminal do odprawy/wyjścia")]
        public virtual Terminal Terminal { get; set; }

        [Display(Name = "Samolot")]
        public virtual Plane Plane { get; set; }

        [Display(Name = "Cel lotu")]
        public virtual Destination Destination { get; set; }
    }
}
