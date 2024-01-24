using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt.Models
{
    [Table("Passengers")]
    public class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Imię")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nazwisko")]
        public string? LastName { get; set; }

        [Required]
        [StringLength(9)]
        [Display(Name = "Numer dokumentu")]
        public string? IDCardNumber { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Obywatelstwo")]
        public string? Citizenship { get; set; }

        public virtual ICollection<FlightPassenger>? FlightPassengers { get; set; }
    }
}
