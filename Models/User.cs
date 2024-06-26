﻿
using APIS.Validators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIS.Models
{
    public enum Gender
    {
        Male,
        Female,
        Others
    }
    [Index(nameof(mobile_no), IsUnique = true, Name = "UniqueIndex")]
    public class User
    {
        private string n = "user";
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(2,ErrorMessage ="Name must have two characters")]
        [MaxLength(50,ErrorMessage = "Name can't be longer than 20 characters")]
        public string Name
        {
            get; set; }
            [StringLength(10)]
        [DefaultValue("user")]
        public string role { get { return n; } set { value = n; } } 
     
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
          public DateTime? DOB { get; set; }= DateTime.Now;

        [Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        
        public string mobile_no { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters.")]

        public string password { get; set; }

        [NotMapped]
        public string c_password { get { return password; } set { value = password; } }
    }
}
