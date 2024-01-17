using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext()
        {

        }
        public MovieDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Comedy> ComedyMovies { get; set; }
        public virtual DbSet<Horror> HorrorMovies { get; set; }
        public virtual DbSet<Documentary> DocumentaryMovies { get; set; }
        public virtual DbSet<UserMovie> UserMovie { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS; Database=MovieCastHubDb; Trusted_Connection=true; TrustServerCertificate=true;");
        }
    }
}
