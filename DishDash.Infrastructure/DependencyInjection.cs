using DishDash.Application.Interfaces;
using DishDash.Infrastructure.Authentication;
using DishDash.Infrastructure.Authentication.JWT;
using DishDash.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DishDash.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? throw new KeyNotFoundException("Can't find a connection string");

            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

            // Jwt Configuration
            services.AddScoped<IJwtService, JwtService>();

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
