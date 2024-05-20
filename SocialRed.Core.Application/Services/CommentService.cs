using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Helpers;
using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.ViewModels.Comment;
using SocialRed.Core.Application.ViewModels.Publication;
using SocialRed.Core.Domain.Entities;

namespace SocialRed.Core.Application.Services
{
    public class CommentService : GenericService<SaveCommentViewModel, CommentViewModel, Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPublicationRepository _publicationRepository;
        private readonly AuthenticationResponse _userViewModel;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public CommentService(ICommentRepository commentRepository,IPublicationRepository publicationRepository , IUserService userService, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(commentRepository, mapper)
        {
            _publicationRepository = publicationRepository;
            _commentRepository = commentRepository;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _mapper = mapper;
            _userService = userService;
        }


        public async Task<List<CommentViewModel>> GetAllCommentOfPublication(int IdPublication)
        {
            var publication = await _publicationRepository.GetById(IdPublication);

            if (publication == null)
            {
                return new List<CommentViewModel>();
            }

            var CommentsPublication = await _commentRepository.GetAllWithInclude(p => p.IdOfPublication == IdPublication);


            var commentsViewModel = _mapper.Map<List<CommentViewModel>>(CommentsPublication);

            foreach (var comment in commentsViewModel)
            {
                var vm = await _userService.GetByIdUserAsync(comment.IdOfUserPublication);

                comment.ImageProfile = vm.ImageProfile;
            }
            return commentsViewModel;
        }


        public override async Task<SaveCommentViewModel> Add(SaveCommentViewModel vm)
        {
            vm.IdOfUserPublication = _userViewModel.Id;
            vm.Created = DateTime.Now;
            vm.CreateBy = _userViewModel.Username;

            var SavedVm = await base.Add(vm);
            return SavedVm;
        }
        public override async Task Update(SaveCommentViewModel vm, int id)
        {
            vm.IdOfUserComment = _userViewModel.Id;
            await base.Update(vm, id);
        }
    }
}
