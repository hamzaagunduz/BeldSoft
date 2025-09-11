using Beldsoft.Application.Interfaces;
using Beldsoft.Infrastructure.Repositories;
using Beldsoft.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Beldsoft.Application.Interfaces.IBlogRepository;
using Beldsoft.Application.Interfaces.IAppUserRepository;
using Beldsoft.Persistence.Repositories;
using Beldsoft.Application.Interfaces.IHeroSectionRepository;
using Beldsoft.Application.Interfaces.IServiceSectionRepository;
using Beldsoft.Application.Interfaces.IAboutSectionRepository;
using Beldsoft.Application.Interfaces.ISessionSectionRepository;
using Beldsoft.Application.Interfaces.IGallerySectionRepository;
using Beldsoft.Application.Interfaces.IFeedbackSectionRepository;

namespace Beldsoft.Persistence.ServiceRegister
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BeldsoftContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );



            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IHeroSectionRepository, HeroSectionRepository>();
            services.AddScoped<IServiceSectionRepository, ServiceSectionRepository>();
            services.AddScoped<IAboutSectionRepository, AboutSectionRepository>();
            services.AddScoped<ISessionSectionRepository, SessionSectionRepository>();
            services.AddScoped<IGallerySectionRepository, GallerySectionRepository>();
            services.AddScoped<IFeedbackSectionRepository, FeedbackSectionRepository>();


        }
    }
}
