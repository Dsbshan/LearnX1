using CustomAuh.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CustomAuh.Entities
{

    [Index(nameof(Email),IsUnique =true)]
    [Index(nameof(UserName),IsUnique =true)]
    public class UserAccount
    {
        [Key]

        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(50,ErrorMessage ="Max 50 Charactors allowed")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is Required")]
        [MaxLength(50, ErrorMessage = "Max 50 Charactors allowed")]

        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is Required")]
        [MaxLength(100, ErrorMessage = "Max 100 Charactors allowed")]

        public string Email { get; set; }
        
        [Required(ErrorMessage = "UserName Name Required")]
        [MaxLength(20, ErrorMessage = "Max 20 Charactors allowed")]
        public string UserName { get; set; }


        [MaxLength(20, ErrorMessage = "Max 20 Charactors allowed")]
        [Required(ErrorMessage = "Password Name Required")]
        public string Password { get; set; }

        public string Role { get; set; } = "User"; // Default to "User", can be "Instructor"

        
        public ICollection<EnrollmentViewModel> Enrollments { get; set; }
    }
}
