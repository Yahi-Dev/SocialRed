using AutoMapper;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.ViewModels.Comment;
using SocialRed.Core.Application.ViewModels.Friends;
using SocialRed.Core.Application.ViewModels.Muro;
using SocialRed.Core.Application.ViewModels.Publication;
using SocialRed.Core.Application.ViewModels.Reply;
using SocialRed.Core.Application.ViewModels.Users;
using SocialRed.Core.Domain.Entities;

namespace SocialRed.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {        
            CreateMap<Publication, PublicationViewModel>()
                    .ReverseMap()
                    .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());


            CreateMap<Publication, SavePublicationViewModel>()
                    .ForMember(dest => dest.FileImg, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());







            CreateMap<Comment, CommentViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ImageUser, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());



            CreateMap<Comment, SaveCommentViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FileImg, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());







            CreateMap<Muro, MuroViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ReverseMap()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());


            CreateMap<Muro, SaveMuroViewModel>()
                    .ForMember(dest => dest.FileImg, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());




            CreateMap<SaveReplyViewModel, ReplyViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());


            CreateMap<Reply, ReplyViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());


            CreateMap<Reply, SaveReplyViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());



            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();




            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<GetByIdUserInIdentityViewModel, FriendViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
                .ForMember(dest => dest.FirtsName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.ImageUser, opt => opt.MapFrom(src => src.ImageProfile))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));


            CreateMap<Friend, SaveFriendViewModel>()
                    .ReverseMap();



            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AuthenticationRequest, LoginViewModel>()
                    .ForMember(dest => dest.HasError, opt => opt.Ignore())
                    .ForMember(dest => dest.Error, opt => opt.Ignore())
                    .ReverseMap();


            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<SaveUserViewModel, GetByIdUserInIdentityViewModel>()
                    .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore())
                    .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
                    .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
                    .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
                    .ReverseMap();


        }
    }
}
