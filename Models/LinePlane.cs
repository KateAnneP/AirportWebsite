using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace projekt.Models
{
    [Table("LinePlanes")]
    public class LinePlane
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinePlaneID { get; set; }

        public int LineId { get; set; }
        public Line? Line { get; set; }

        public int PlaneId { get; set; }
        public Plane? Plane { get; set; }

    }
}
