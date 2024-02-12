using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIS.Models
{
    public class Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int r_id { get; set; }

        [Required]
        [StringLength(50)]
        public string source { get; set; }

        [Required]
        [StringLength(50)]
        public string destination { get; set; }

        [Required]
        public int distance { get; set;}
        [Required]
        public int duration { get; set;}
 }
}
