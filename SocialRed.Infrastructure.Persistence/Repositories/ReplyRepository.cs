using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Core.Domain.Entities;
using SocialRed.Infrastructure.Persistence.Contexts;

namespace SocialRed.Infrastructure.Persistence.Repositories
{
    public class ReplyRepository : GenericsRepository<Reply>, IReplyRepository
    {
        private readonly ApplicationContext _dbcontext;

        public ReplyRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _dbcontext = applicationContext;
        }
    }
}
