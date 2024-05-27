using Project.Core.Services;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Project.Database.Context;
using Project.Database.Repositories;
using Microsoft.OpenApi.Models;

namespace Project.Api
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<GundamsServices>();
            services.AddScoped<UsersServices>();
            services.AddScoped<AuthService>();

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
            services.AddScoped<RolesRepository>();
            services.AddScoped<UsersRepository>();

        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Lab project API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {   
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    }
                });
            });
        }
    }
}
