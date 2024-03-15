using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace APIS.Models
{
    [Index(nameof(mobileno), IsUnique = true, Name = "UniqueIndexD")]
    public class Driver
    {
        private string n = "driver";
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int d_id { get; set; }


        [StringLength(10)]
        [DefaultValue("driver")]
        public string role { get { return n; } set { value = n; } }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        [MinLength(2, ErrorMessage = "Name must have two characters")]
        [MaxLength(50, ErrorMessage = "Name can't be longer than 20 characters")]
        public string d_name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(128)]
        [MaxLength(128,ErrorMessage ="Address can't be longer...")]
        public string address { get; set; }
     
        [Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string mobileno { get; set; }

        [Required(ErrorMessage = "license no. is required")]
        [StringLength(50)]
        public string licenseno { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters.")]

        public string password { get; set; }

        [NotMapped]
        public string c_password { get { return password; } set { value = password; } }
    }
}
