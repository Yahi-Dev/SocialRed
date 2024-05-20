using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Infrastructure.Persistence.Contexts;
using SocialRed.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"), m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericsRepository<>), typeof(GenericsRepository<>));
            services.AddTransient<IPublicationRepository, PublicationRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IReplyRepository, ReplyRepository>();
            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddTransient<IMuroRepository, MuroRepository>();
            #endregion
        }
    }
}
