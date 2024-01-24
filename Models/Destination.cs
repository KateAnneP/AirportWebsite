using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt.Models
{
    [Table("Destinations")]
    public class Destination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nazwa miasta")]
        public string? City { get; set; }    /*nazwa miasta*/

        [Required]
        [StringLength(3)]
        [Display(Name = "Skrót")]
        public string? Shortcut { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Kraj")]
        public string? Country { get; set; }

        public virtual ICollection<Flight>? Flights { get; set; } //Loty do tej lokacji
    }
}
