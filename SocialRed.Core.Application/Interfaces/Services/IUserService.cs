using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.ViewModels.Users;

namespace SocialRed.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasssowrdAsync(ForgotPasswordViewModel vm, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin);
        Task ResetPasssowrdAsync(ResetPasswordViewModel vm);
        Task<SaveUserViewModel> GetByIdUserAsync(string id);
        Task UpdateInfoAccount(SaveUserViewModel vm);
        Task SignOutAsync();
    }
}