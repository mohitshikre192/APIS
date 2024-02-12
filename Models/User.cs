
using APIS.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIS.Models
{
    public enum Gender
    {
        Male,
        Female,
    }
    public class User
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(2,ErrorMessage ="Name must have two characters")]
        [MaxLength(50,ErrorMessage = "Name can't be longer than 20 characters")]
          public string Name { get; set; }
            [Required]
          public Gender gender { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Verify email is invalid")]
          public string Email { get; set; }
        [Required]
        [MinimumAge(18)]
        [MaxAge(100)]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
          public DateTime DOB { get; set; }
  }
}
