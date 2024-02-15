
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int b_id { get; set; }
        [ForeignKey("Vehicle")]
        public string v_id { get; set; }   
        public virtual Vehicle Vehicle { get; set; }

        [Required]
        public DateTime Booking_Date { get; set; }
        [Required]
        public DateTime Journey_Date { get; set; }

        [ForeignKey("Route")]
        public int r_id { get; set; }
        public Route Route { get; set; }
        public string drop_Point { get; set; }
        public string boarding_Point { get; set; }
        public int noofPassenger { get; set; }
        public bool bookingstatus { get; set; }
    }
}
