#nullable disable
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Comedy> ComedyMovies { get; set; }
        public virtual DbSet<Horror> HorrorMovies { get; set; }
        public virtual DbSet<Documentary> DocumentaryMovies { get; set; }
        public virtual DbSet<UserMovie> UserMovie { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }


    }
}

