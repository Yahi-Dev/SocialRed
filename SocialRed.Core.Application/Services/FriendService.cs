using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Helpers;
using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.ViewModels.Friends;
using SocialRed.Core.Domain.Entities;


namespace SocialRed.Core.Application.Services
{
    public class FriendService : GenericService<SaveFriendViewModel, FriendViewModel, Friend>, IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse _userViewModel;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public FriendService
        (IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IFriendRepository friendRepository, 
        IAccountService accountService) : base(friendRepository, mapper)
        {
            _accountService = accountService;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _mapper = mapper;
            _friendRepository = friendRepository;
        }

        public async Task<List<FriendViewModel>> GetAllYoursFriends(string IdUser)
        {
            var friends = await _friendRepository.GetAllWithInclude(f => f.IdUserApplicant == IdUser);

            List<FriendViewModel> Vmfriends = new();

            foreach (var friend in friends)
            {
                var FriendProfile = await _accountService.GetByIdUser(friend.IdUserFollowed);
                FriendProfile.IdRelashionship = friend.Id;
                var p = _mapper.Map<FriendViewModel>(FriendProfile);
                Vmfriends.Add(p);
            }
            return Vmfriends;
        }

        public async Task<bool> AddFriend(SaveFriendViewModel vm)
        {
            var p = await _accountService.GetUserIdByUsernameAsync(vm.UserNameFriend);

            if (p != null)
            {
                Friend friend = new();
                friend.IdUserApplicant = vm.IdUSerSearchFriend;
                friend.IdUserFollowed = p;
                await _friendRepository.AddAsync(friend);
                return true;
            }
            return false;
        }
    }
}
