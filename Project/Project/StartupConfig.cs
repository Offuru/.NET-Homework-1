using Project.Core.Services;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Project.Database.Context;

namespace Project.Api
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<GundamsServices>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext>();
            services.AddScoped<DbContext, ProjectDbContext>();
        }
    }
}
