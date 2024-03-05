using System.ComponentModel.DataAnnotations.Schema;

namespace APIS.Models
{
    public class Login
    {

        public int Id { get; set; }

        [ForeignKey("Driver")]
        public string Username { get; set; }


        public string Password { get; set; }
    }
    
}
