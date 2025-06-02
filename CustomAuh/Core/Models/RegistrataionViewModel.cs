using System.ComponentModel.DataAnnotations;

namespace CustomAuh.Models
{
    public class RegistrataionViewModel
    {
        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(50, ErrorMessage = "Max 50 Charactors allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [MaxLength(50, ErrorMessage = "Max 50 Charactors allowed")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [MaxLength(100, ErrorMessage = "Max 100 Charactors allowed")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please Enter Valid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName Name Required")]
        [MaxLength(20, ErrorMessage = "Max 20 Charactors allowed")]
        public string UserName { get; set; }


        [StringLength(20,MinimumLength =5, ErrorMessage = "Max 20 or Min 5 Charactors allowed")]
        [Required(ErrorMessage = "Password Name Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Pleasr Confirm Your Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; } = "User";
    }
}
