using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt.Models
{
    [Table("Lines")]
    public class Line
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nazwa linii")]
        public string? Name { get; set; }    /*nazwa linii*/

        [Required]
        [StringLength(10)]
        [Display(Name = "Skrót")]
        public string? Shortcut { get; set; }

        public virtual ICollection<Flight>? Flights { get; set; }

        public virtual ICollection<LinePlane>? LinePlanes { get; set; }
    }
}
