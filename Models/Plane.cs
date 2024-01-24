using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt.Models
{
    [Table("Planes")]
    public class Plane
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Model samolotu")]
        public string? Model { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Skrót")]
        public string? Shortcut { get; set; }

        public virtual ICollection<Flight>? Flights { get; set; }
        public virtual ICollection<LinePlane>? LinePlanes { get; set; }

    }
}
