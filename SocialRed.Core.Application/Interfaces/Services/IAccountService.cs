using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.ViewModels.Users;

namespace SocialRed.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin);
        Task ResetPasswordAsync(ResetPasswordRequest request);
        Task<GetByIdUserInIdentityViewModel> GetByIdUser(string id);
        Task UpdateInfoAccount(SaveUserViewModel vm);
        Task SignOutAsync();
        Task<string> GetUserIdByUsernameAsync(string username);
    }
}
