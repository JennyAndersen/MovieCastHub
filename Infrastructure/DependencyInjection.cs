using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-B0SACG3; Database=MovieCastHubDb; Trusted_Connection=true; TrustServerCertificate=true;");

            });

            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
