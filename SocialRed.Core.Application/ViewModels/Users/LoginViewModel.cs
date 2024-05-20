using System.ComponentModel.DataAnnotations;

namespace SocialRed.Core.Application.ViewModels.Users
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
        [DataType(DataType.Text)]
        public string Email { get; set; }



        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }


        public string? Error { get; set; }
        public bool? HasError { get; set; }
    }
}
