namespace Application.Dtos.Movie
{
    public class ComedyMovieDto
    {
        public required string Title { get; set; }
        public required string Director { get; set; }
        public int Duration { get; set; }
        public float Rating { get; set; }
        public required string HumorStyle { get; set; }
        public bool FamilyFriendly { get; set; }
        public bool ParodyElements { get; set; }
    }
}
