using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.Helpers;
using SocialRed.Core.Application.Services;
using SocialRed.Core.Application.ViewModels.Comment;
using SocialRed.Core.Application.ViewModels.Reply;

namespace SocialRed.Controllers
{
    [Authorize]
    public class ReplyController : Controller
    {
        private readonly IReplyService _replyService;
        private readonly ICommentService _commentService;
        private readonly AuthenticationResponse _userViewModel;
        public Singlenton singlentonReply = Singlenton.Instance;

        public ReplyController(IReplyService replyService, ICommentService commentService,
            IHttpContextAccessor httpContextAccessor)
        {
            _replyService = replyService;
            _userViewModel = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _commentService = commentService;

        }
        public async Task<IActionResult> ViewReply(int id)
        {
            if (id != 0)
            {
                singlentonReply.Value = id;
            }

            return View("ViewReply", await _replyService.GetAllReplyOfcomment(singlentonReply.Value));
        }

        public async Task<IActionResult> ReplyComment(int id)
        {
            if (id != 0)
            {
                singlentonReply.Value = id;
            }


            SaveReplyViewModel vm = new();
            var comment = await _commentService.GetByIdSaveViewModel(singlentonReply.Value);
            vm.CommentReply = comment.Comments;
            vm.ImageUserOfCreateComment = comment.ImageUser;
            vm.IUsernameUserOfCreateComment = comment.CreateBy;
            vm.OfCreatedComment = comment.Created;
            return View("Create", vm);
        }


        [HttpPost]
        public async Task<IActionResult> ReplyComment(SaveReplyViewModel vm)
        {
            SaveReplyViewModel vmId = new();

            vm.Id = vmId.Id;
            vm.IdComment = singlentonReply.Value;
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            SaveReplyViewModel p = await _replyService.AddReply(vm);
            return RedirectToRoute(new { controller = "Reply", action = "ViewReply" });
        }

    }
}
