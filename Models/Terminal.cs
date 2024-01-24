using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt.Models
{
    [Table("Terminals")]
    public class Terminal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Opis")]
        public string? Description { get; set; }

        public virtual ICollection<Flight>? Flights { get; set; }

    }
}