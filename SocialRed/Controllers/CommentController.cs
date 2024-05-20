using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.ViewModels.Comment;
using SocialRed.Core.Application.Helpers;
using SocialRed.Core.Domain.Entities;
using SocialRed.Core.Application.Services;
using Microsoft.AspNetCore.Authorization;


namespace SocialRed.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly AuthenticationResponse _userViewModel;
        private readonly ICommentService _commentService;
        public Singlenton singlentonComment = Singlenton.Instance;

        public CommentController(ICommentService commentService, IHttpContextAccessor httpContextAccessor)
        {
            _userViewModel = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _commentService = commentService;
        }

        public async Task<IActionResult> Comments(int id)
        {
            if (id != 0)
            {
                singlentonComment.Value = id;
            }

            return View("ViewAndComment", await _commentService.GetAllCommentOfPublication(singlentonComment.Value));
        }

        public async Task<IActionResult> AddComment()
        {
            SaveCommentViewModel vm = new();
            return View("Create", vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentPost(SaveCommentViewModel vm)
        {

            vm.IdOfUserComment = _userViewModel.Id;
            vm.IdOfPublication = singlentonComment.Value;

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            SaveCommentViewModel  p = await _commentService.Add(vm);
            return View("ViewAndComment", await _commentService.GetAllCommentOfPublication(singlentonComment.Value));
        }
    }
}
