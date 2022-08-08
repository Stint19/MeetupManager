using MeetupManager.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeetupManager.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<MeetupDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            services.AddScoped<IMeetupDbContext>(provider =>
                provider.GetService<MeetupDbContext>());
            return services;
        }
    }
}
