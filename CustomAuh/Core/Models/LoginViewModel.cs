using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomAuh.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName Or Email Required")]
        [MaxLength(30, ErrorMessage = "Max 30 Charactors allowed")]
        [DisplayName("UserName or Email")]
        public string UserNameOrEmail { get; set; }


        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 or Min 5 Charactors allowed")]
        [Required(ErrorMessage = "Password Name Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
