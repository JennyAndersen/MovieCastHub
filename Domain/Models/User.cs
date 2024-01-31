#nullable disable
namespace Domain.Models
{
    public class User
    {
        public static object Count;

        public Guid UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public ICollection<UserMovie> UserMovies { get; set; }
    }
}
