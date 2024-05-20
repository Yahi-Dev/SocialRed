using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Domain.Settings;
using SocialRed.Infrastructure.Shared.Services;

namespace SocialRed.Infrastructure.Shared
{
    public static class ServiceRegistratrion
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
