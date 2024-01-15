#nullable disable
namespace Domain.Models
{
    public class Movie
    {
        public Guid MovieId { get; set; }
        public required string Title { get; set; }
        public required string Director { get; set; }
        public int Duration { get; set; }
        public float Rating { get; set; }
        public ICollection<UserMovie> UserMovies { get; set; }
    }
}
