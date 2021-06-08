using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PF6_Team1_DotNetAssignment.Database;
using PF6_Team1_DotNetAssignment.Services;
using PF6_Team1_DotNetAssignment.Services.Implementations;
using System;

namespace PF6_Team1_DotNetAssignment
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices (this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPackageService, PackageService>();
            return services;
        }

        public static IServiceCollection AddPersistance (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Team1DbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(Team1DbContext).Assembly.FullName)));

            return services;
        }

        public static IServiceCollection AddSession (this IServiceCollection services, IConfiguration configuration)
        {
            //1 For session management

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(6000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            //
            return services;
        }
    }
}
