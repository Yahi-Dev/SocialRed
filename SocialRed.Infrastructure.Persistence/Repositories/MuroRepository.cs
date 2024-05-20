using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Core.Domain.Entities;
using SocialRed.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Infrastructure.Persistence.Repositories
{
    public class MuroRepository : GenericsRepository<Muro>, IMuroRepository
    {
        private readonly ApplicationContext _dbcontext;

        public MuroRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _dbcontext = applicationContext;
        }
    }
}
