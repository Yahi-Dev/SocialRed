using AutoMapper;
using SocialRed.Core.Application.ViewModels.Reply;
using SocialRed.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using SocialRed.Infrastructure.Identity.Entities;
using SocialRed.Core.Application.DTOs.Account;

namespace SocialRed.Infrastructure.Identity.Mappings
{
    public class GeneralAccount : Profile
    {
        public GeneralAccount()
        {
            CreateMap<ApplicationUser, GetByIdUserInIdentityViewModel>()
                .ReverseMap();


            CreateMap<ApplicationUser, SaveUserViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore())
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore());

            CreateMap<ApplicationUser, ResetPasswordRequest>()
                    .ReverseMap()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        }
    }
}