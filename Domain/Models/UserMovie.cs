#nullable disable

namespace Domain.Models
{
    public class UserMovie
    {
        public static readonly object Count;

        public Guid UserMovieId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public float UserRating { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
