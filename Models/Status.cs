using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt.Models
{
    [Table("Status")]
    public class Status
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
