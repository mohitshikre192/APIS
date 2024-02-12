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
        public string v_name { get; set; }
        public int sitting_cap { get; set; }
       
        public string v_type { get; set; }
        public int fare {  get; set; }

        public int d_id { get; set; }
    }
}
