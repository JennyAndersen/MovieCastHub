namespace Application.Dtos.Movie
{
    public class ComedyMovieDto : MovieDto
    {
        public required string HumorStyle { get; set; }
        public required bool FamilyFriendly { get; set; }
        public required bool ParodyElements { get; set; }
    }
}
