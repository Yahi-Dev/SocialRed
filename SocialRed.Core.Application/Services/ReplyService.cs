using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Helpers;
using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.ViewModels.Comment;
using SocialRed.Core.Application.ViewModels.Reply;
using SocialRed.Core.Domain.Entities;


namespace SocialRed.Core.Application.Services
{
    public class ReplyService : GenericService<SaveReplyViewModel, ReplyViewModel, Reply>, IReplyService
    {
        private readonly IReplyRepository _replyRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICommentRepository _commentRepository;
        private readonly AuthenticationResponse _userViewModel;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ReplyService(IReplyRepository replyRepository, ICommentRepository commentRepository, 
            IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService) : base(replyRepository, mapper)
        {
            _commentRepository = commentRepository;
            _replyRepository = replyRepository;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _mapper = mapper;
            _userService = userService;
        }


        public async Task<List<ReplyViewModel>> GetAllReplyOfcomment(int Idcomment)
        {
            var comment = await _commentRepository.GetById(Idcomment);

            if (comment == null)
            {
                return new List<ReplyViewModel>();
            }

            var replyPublication = await _replyRepository.GetAllWithInclude(p => p.IdComment == Idcomment);

            var replyViewModel = _mapper.Map<List<ReplyViewModel>>(replyPublication);

            foreach (var reply in replyViewModel)
            {
                var vm = await _userService.GetByIdUserAsync(reply.IdUserReply);

                reply.ImageUser = vm.ImageProfile;
            }

            return replyViewModel;
        }


        public async Task<SaveReplyViewModel> AddReply(SaveReplyViewModel vm)
        {
            vm.IdUserReply = _userViewModel.Id;
            vm.Created = DateTime.Now;
            vm.CreateBy = _userViewModel.Username;
            var p = await _commentRepository.GetById(vm.IdComment ?? 0);
            vm.IdPublication = p.IdOfPublication;
            vm.CommentReply = p.Comments;
            var SavedVm = await base.Add(vm); 
            //var vmTranfer = await _replyRepository.GetById(SavedVm.Id);
            //p.IdReply = vmTranfer.Id;
            //var reply =  _mapper.Map<ReplyViewModel>(SavedVm);
            //await _commentRepository.UpdateAsync(p, p.Id);
            return SavedVm;
        }

        public override async Task Update(SaveReplyViewModel vm, int id)
        {
            vm.IdUserReply = _userViewModel.Id;
            await base.Update(vm, id);
        }
    }
}
