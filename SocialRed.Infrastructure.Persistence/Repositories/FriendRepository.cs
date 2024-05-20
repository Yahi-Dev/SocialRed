using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Core.Domain.Entities;
using SocialRed.Infrastructure.Persistence.Contexts;

namespace SocialRed.Infrastructure.Persistence.Repositories
{
    public class FriendRepository : GenericsRepository<Friend>, IFriendRepository
    {
        private readonly ApplicationContext _dbcontext;

        public FriendRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _dbcontext = applicationContext;
        }

    }
}
