using Project.Core.Services;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Project.Database.Context;
using Project.Database.Repositories;

namespace Project.Api
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<GundamsServices>();
            services.AddScoped<UsersServices>();
            services.AddMvc().AddNewtonsoftJson(
                options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
                });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext>();
            services.AddScoped<DbContext, ProjectDbContext>();

            services.AddScoped<GundamsRepository>();
            services.AddScoped<UsersRepository>();
        }
    }
}
