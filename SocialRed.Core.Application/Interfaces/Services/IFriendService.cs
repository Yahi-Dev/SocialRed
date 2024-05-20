using SocialRed.Core.Application.ViewModels.Friends;
using SocialRed.Core.Domain.Entities;


namespace SocialRed.Core.Application.Interfaces.Services
{
    public interface IFriendService : IGenericService<SaveFriendViewModel, FriendViewModel, Friend>
    {
        Task<List<FriendViewModel>> GetAllYoursFriends(string IdUser);

        Task<bool> AddFriend(SaveFriendViewModel vm);
    }
}
