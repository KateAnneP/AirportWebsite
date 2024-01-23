using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt.Models
{
    [Table("Staffs")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Stanowisko")]
        public string Position { get; set; }

        public virtual ICollection<FlightStaff> FlightStaffs { get; set; }
    }
}
