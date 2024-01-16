#nullable disable
namespace Domain.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public ICollection<UserMovie> UserMovies { get; set; }
    }
}
