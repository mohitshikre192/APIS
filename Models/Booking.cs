
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int b_id { get; set; }
        public int v_id { get; set; }   
        public DateTime Booking_Date { get; set; }
        public DateTime Journey_Date { get; set; }
        public int r_id { get; set; }
        public string drop_Point { get; set; }
        public string boarding_Point { get; set; }
        public int noofPassenger { get; set; }
        public bool bookingstatus { get; set; }
    }
}
