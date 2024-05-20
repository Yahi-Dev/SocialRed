
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SocialRed.Core.Application.ViewModels.Users
{
    public class SaveUserViewModel
    {
        public string? IdUser {  get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }




        [Required(ErrorMessage = "Debe colocar el apellido del usuario")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }





        [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }



        public string? ImageProfile { get; set; }


        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string? PasswordHash { get; set; }



        [Compare(nameof(PasswordHash), ErrorMessage ="Las Contraseñas deben coincidir")]
        [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        



        [Required(ErrorMessage = "Debe colocar un correo")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        public string Country { get; set; }



        [Required(ErrorMessage = "Debe colocar un telefono")]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }





        [DataType(DataType.Upload)]
        public IFormFile? FileImg { get; set; }


        public string? Error { get; set; }
        public bool? HasError { get; set; }
    }
}
