using Infrastructure.Data;
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
                options.UseSqlServer("Server=LUCASDATOR\\SQLEXPRESS; Database=MovieCastHubDb; Trusted_Connection=true; TrustServerCertificate=true;");

            });
            return services;
        }
    }
}
