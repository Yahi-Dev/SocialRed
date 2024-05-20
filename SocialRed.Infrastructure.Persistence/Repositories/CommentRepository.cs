using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Core.Domain.Entities;
using SocialRed.Infrastructure.Persistence.Contexts;


namespace SocialRed.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : GenericsRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationContext _dbcontext;

        public CommentRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _dbcontext = applicationContext;
        }
    }
}
