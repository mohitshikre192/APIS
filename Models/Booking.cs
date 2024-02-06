using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIS.Models
{
    public class Booking
    {
        public int b_id { get; set; }
        public int v_id { get; set; }   
        public DateTime BookingDate { get; set; }
        public DateTime JourneyDate { get; set; }
        public int r_id { get; set; }
        public string dropPoint { get; set; }
        public string boardingPoint { get; set; }
        public int noofPassenger { get; set; }
        public bool bookingstatus { get; set; }
    }
}
