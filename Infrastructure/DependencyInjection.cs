using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
