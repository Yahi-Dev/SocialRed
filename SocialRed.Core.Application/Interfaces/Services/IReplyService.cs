using SocialRed.Core.Application.ViewModels.Muro;
using SocialRed.Core.Application.ViewModels.Reply;
using SocialRed.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.Interfaces.Services
{
    public interface IReplyService : IGenericService<SaveReplyViewModel, ReplyViewModel, Reply>
    {
        Task<List<ReplyViewModel>> GetAllReplyOfcomment(int Idcomment);
        Task<SaveReplyViewModel> AddReply(SaveReplyViewModel vm);
    }
}
