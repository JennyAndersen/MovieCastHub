using Domain.Models;

namespace Infrastructure.Data
{
    public static class DataBaseSeedHelper
    {
        private static readonly Random random = new();
        private static readonly List<string> Usernames = new() { "user1", "user2", "user3", "user4", "user5" };
        private static readonly List<string> MovieTitles = new() { "Scary Movie", "The World of Birds", "The Funny Bone", "Ocean's Mystery", "Space Adventure" };
        private static readonly List<string> Directors = new() { "Director1", "Director2", "Director3", "Director4", "Director5" };

        public static void SeedData(MovieDbContext dbContext)
        {
            SeedUsers(dbContext);
            SeedMovies(dbContext);
            SeedUserMovies(dbContext);
        }

        private static void SeedUsers(MovieDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var roles = new List<string> { "Admin", "User", "SuperUser" };
                for (int i = 0; i < 5; i++)
                {
                    dbContext.Users.Add(new User
                    {
                        UserId = Guid.NewGuid(),
                        Username = Usernames[i % Usernames.Count],
                        Password = BCrypt.Net.BCrypt.HashPassword("password" + (i + 1)),
                        Role = roles[i % roles.Count]
                    });
                }
                dbContext.SaveChanges();
            }
        }

        private static void SeedMovies(MovieDbContext dbContext)
        {
            if (!dbContext.Movies.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    Movie movie;
                    if (i % 3 == 0)
                    {
                        movie = new Horror
                        {
                            MovieId = Guid.NewGuid(),
                            Title = MovieTitles[i % MovieTitles.Count],
                            Director = Directors[i % Directors.Count],
                            Duration = random.Next(80, 180),
                            Rating = random.Next(1, 10),
                            ScaryLevel = random.Next(1, 10),
                            SupernaturalElements = random.Next(2) == 0,
                            GoreLevel = random.Next(1, 10)
                        };
                    }
                    else if (i % 3 == 1)
                    {
                        movie = new Documentary
                        {
                            MovieId = Guid.NewGuid(),
                            Title = MovieTitles[i % MovieTitles.Count],
                            Director = Directors[i % Directors.Count],
                            Duration = random.Next(80, 180),
                            Rating = random.Next(1, 10),
                            HistoricalContext = "Historical Context " + i,
                            RealLifeContext = "Real Life Context " + i
                        };
                    }
                    else
                    {
                        movie = new Comedy
                        {
                            MovieId = Guid.NewGuid(),
                            Title = MovieTitles[i % MovieTitles.Count],
                            Director = Directors[i % Directors.Count],
                            Duration = random.Next(80, 180),
                            Rating = random.Next(1, 10),
                            HumorStyle = "Style " + i,
                            FamilyFriendly = random.Next(2) == 0,
                            ParodyElements = random.Next(2) == 0
                        };
                    }
                    dbContext.Movies.Add(movie);
                }
                dbContext.SaveChanges();
            }
        }

        private static void SeedUserMovies(MovieDbContext dbContext)
        {
            if (!dbContext.UserMovie.Any())
            {
                var users = dbContext.Users.ToList();
                var movies = dbContext.Movies.ToList();
                for (int i = 0; i < Math.Min(users.Count, movies.Count); i++)
                {
                    dbContext.UserMovie.Add(new UserMovie
                    {
                        UserMovieId = Guid.NewGuid(),
                        UserId = users[i].UserId,
                        MovieId = movies[i].MovieId
                    });
                }
                dbContext.SaveChanges();
            }
        }
    }
}
