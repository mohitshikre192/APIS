using Microsoft.EntityFrameworkCore;

namespace APIS.Models
{
    public class Vehicle
    {
       
        public string vno { get; set; }
        public string vname { get; set; }
        public int sittingcap { get; set; }
        public int did {  get; set; }
        public string vtype { get; set; }

        public int fare {  get; set; }

     


    }
}
