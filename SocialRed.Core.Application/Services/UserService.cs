using AutoMapper;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.ViewModels.Users;

namespace SocialRed.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountservice;
        private readonly IMapper _mapper;

        public UserService(IAccountService accountservice, IMapper mapper)
        {
            _accountservice = accountservice;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel vm)
        {
            AuthenticationRequest loginrequest = _mapper.Map<AuthenticationRequest>(vm);

            AuthenticationResponse userResponse = await _accountservice.AuthenticateAsync(loginrequest);
            return userResponse;
        }

        public async Task SignOutAsync()
        {
            await _accountservice.SignOutAsync();
        }

        public async Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin)
        {
            RegisterRequest registerRequest = _mapper.Map<RegisterRequest>(vm);
            return await _accountservice.RegisterBasicUserAsync(registerRequest, origin);
        }

        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            return await _accountservice.ConfirmAccountAsync(userId, token);
        }

        public async Task<ForgotPasswordResponse> ForgotPasssowrdAsync(ForgotPasswordViewModel vm, string origin)
        {
            ForgotPasswordRequest forgotRequest = _mapper.Map<ForgotPasswordRequest>(vm);
            return await _accountservice.ForgotPasswordAsync(forgotRequest, origin);
        }

        public async Task ResetPasssowrdAsync(ResetPasswordViewModel vm)
        {
            ResetPasswordRequest resetRequest = _mapper.Map<ResetPasswordRequest>(vm);
             await _accountservice.ResetPasswordAsync(resetRequest);
        }

        public async Task<SaveUserViewModel> GetByIdUserAsync(string id)
        {
            var p =  await _accountservice.GetByIdUser(id);
            SaveUserViewModel vm = _mapper.Map<SaveUserViewModel>(p);
            return vm;
        }

        public async Task UpdateInfoAccount(SaveUserViewModel vm)
        {
           await _accountservice.UpdateInfoAccount(vm);
        }
    }
}
