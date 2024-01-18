namespace Application.Dtos.Movie
{
    public class HorrorMovieDto
    {
        public required string Title { get; set; }
        public required string Director { get; set; }
        public int Duration { get; set; }
        public float Rating { get; set; }
        public int ScaryLevel { get; set; }
        public bool SupernaturalElements { get; set; }
        public int GoreLevel { get; set; }

    }
}
