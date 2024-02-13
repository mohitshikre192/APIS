using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public class Vehicle
    {
        [Key]
        [Required]
        [StringLength(15)]
        [MinLength(13,ErrorMessage ="Vehicle number must be valid")]
        [MaxLength(15,ErrorMessage ="Vehicle number can't be that long")]
        public string v_no { get; set; }

        [Required]
        [StringLength(128)]
        [MinLength(3,ErrorMessage ="Vehicle name atleast have 3 characters:")]
        public string v_name { get; set; }
        [Required]
        [Range(3,12)]
        public int sitting_cap { get; set; }
        [Required]
        [StringLength(128)]
        [MinLength(2,ErrorMessage ="Atleast define Vehicle type with more than 2 character")]
        
        public string v_type { get; set; }
        [Required(ErrorMessage ="Fare per km is a required!!!")]
        public int fare {  get; set; }
        [ForeignKey("Driver")]
        public int d_id { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
