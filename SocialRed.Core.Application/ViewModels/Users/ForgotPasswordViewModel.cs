using System.ComponentModel.DataAnnotations;


namespace SocialRed.Core.Application.ViewModels.Users
{
    public class ForgotPasswordViewModel
    {
        public string UserName { get; set; }
        public string? Error { get; set; }
        public bool? HasError { get; set; }
    }
}
