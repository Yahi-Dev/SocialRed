using Microsoft.AspNetCore.Mvc;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.Helpers;
using SocialRed.Core.Application.Services;
using SocialRed.Core.Application.ViewModels.Friends;
using SocialRed.Middelwares;
using Microsoft.AspNetCore.Authorization;

namespace SocialRed.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        private readonly AuthenticationResponse _userViewModel;
        public Singlenton singlentonComment = Singlenton.Instance;
        private readonly IPublicationService _publicationService;
        private readonly IFriendService _friendService;

        public FriendController(IHttpContextAccessor httpContextAccessor, IPublicationService publicationService,
          IFriendService friendService)
        {
            _userViewModel = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _publicationService = publicationService;
            _friendService = friendService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _publicationService.GetAllPublicationOfFriend(_userViewModel.Id));
        }


        public async Task<IActionResult> AddFriend()
        {
            SaveFriendViewModel vm = new();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddFriend(SaveFriendViewModel vm)
        {
            vm.IdUSerSearchFriend = _userViewModel.Id;
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var p = await _friendService.AddFriend(vm);
            if (p == false)
            {
                ViewBag.Friend = "Usuario no existente";
                return View(vm);
            }
            return RedirectToRoute(new { controller = "Friend", action = "Index" });
        }

        public async Task<IActionResult> ViewFriend()
        {
            var vm = await _friendService.GetAllYoursFriends(_userViewModel.Id);
            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var p = await _friendService.GetByIdSaveViewModel(id);
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _friendService.Delete(id);
            return RedirectToRoute(new { controller = "Friend", action = "ViewFriend" });
        }
    }
}