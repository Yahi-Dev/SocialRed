using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Helpers;
using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.ViewModels.Publication;
using SocialRed.Core.Domain.Entities;

namespace SocialRed.Core.Application.Services
{
    public class PublicationService : GenericService<SavePublicationViewModel, PublicationViewModel, Publication>,IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IFriendRepository _friendRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse _userViewModel;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public PublicationService
        (IPublicationRepository publicationRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IFriendRepository friendRepository,
        IUserService userService) : base(publicationRepository, mapper)
        {
            _publicationRepository = publicationRepository;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _mapper = mapper;
            _friendRepository = friendRepository;
            _userService = userService;
        }

        public async Task<List<PublicationViewModel>> GetAllPublicationOfFriend(string IdUser)
        {
            var friends = await _friendRepository.GetAllWithInclude(f => f.IdUserApplicant == IdUser);

            List<PublicationViewModel> publications = new();
            foreach (var friend in friends)
            {
                var friendPublications = await _publicationRepository.GetAllWithInclude(p => p.IdOfUserPublication == friend.IdUserFollowed);

                foreach (var publication in friendPublications)
                {
                    var publicationViewModel = _mapper.Map<PublicationViewModel>(publication);
                    publications.Add(publicationViewModel);
                }
            }
           var  publicationOrder =  publications.OrderByDescending(p => p.Created).ToList();
           return publicationOrder;
        }

        public async Task<List<PublicationViewModel>> GetAllPublicationOfUser(string UserId)
        {
            var userPublications = await _publicationRepository.GetAllWithInclude( p => p.IdOfUserPublication ==  UserId);


            var publicationViewModel = _mapper.Map<List<PublicationViewModel>>(userPublications);
            
            foreach (var item in publicationViewModel)
            {
                var p = await _userService.GetByIdUserAsync(item.IdOfUserPublication);
                item.NameUser = p.UserName;
                item.ImageUser = p.ImageProfile;
            }


            publicationViewModel = publicationViewModel.OrderByDescending(p => p.Created).ToList();

            return publicationViewModel;
        }


        public override async Task<SavePublicationViewModel> Add(SavePublicationViewModel vm)
        {
            vm.IdOfUserPublication = _userViewModel.Id;
            vm.Created = DateTime.Now;
            vm.CreateBy = _userViewModel.Username;
            if (vm.ImagePublication == null)
            {
                vm.ImagePublication = "None";
            }
            if (vm.UrlVideoPublication == null)
            {
                vm.UrlVideoPublication = "None";
            }
            var SavedVm = await base.Add(vm);
            return SavedVm;
        }

        public override async Task Update(SavePublicationViewModel vm, int id)
        {
            vm.IdOfUserPublication = _userViewModel.Id;
            vm.Created = DateTime.Now;
            vm.CreateBy = _userViewModel.Username;
            await base.Update(vm, id);
        }


    }
}
