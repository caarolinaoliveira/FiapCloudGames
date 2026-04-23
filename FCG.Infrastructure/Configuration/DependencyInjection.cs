using FCG.Domain.Interfaces;
using FCG.Infrastructure.Context;
using FCG.Infrastructure.Identity;
using FCG.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FCG.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<FcgDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("FCG.Infrastructure")
                ));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<FcgDbContext>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IJogoRepository, JogoRepository>();

            return services;
        }
    }
}