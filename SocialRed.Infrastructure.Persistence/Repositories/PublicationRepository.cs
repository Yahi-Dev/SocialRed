using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Core.Domain.Entities;
using SocialRed.Infrastructure.Persistence.Contexts;

namespace SocialRed.Infrastructure.Persistence.Repositories
{
    public class PublicationRepository : GenericsRepository<Publication>, IPublicationRepository
    {
        private readonly ApplicationContext _dbcontext;

        public PublicationRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _dbcontext = applicationContext;
        }

    }
}
