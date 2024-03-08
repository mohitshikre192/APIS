using System.ComponentModel.DataAnnotations.Schema;

namespace APIS.Models
{
    public class Login
    {

        public string mobile_no{ get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
    
}
