using FCG.Domain.Interfaces;
using FCG.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FCG.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }
    }
}