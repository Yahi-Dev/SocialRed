using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.Services;
using System.Reflection;

namespace SocialRed.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            services.AddTransient<IPublicationService, PublicationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<IMuroService, MuroService>();
            services.AddTransient<IReplyService, ReplyService>();

            #endregion
        }
    }
}
