namespace Application.Dtos.Movie
{
    public class DocumentaryMovieDto
    {
        public required string Title { get; set; }
        public required string Director { get; set; }
        public int Duration { get; set; }
        public float Rating { get; set; }
        public required string HistoricalContext { get; set; }
        public required string RealLifeContext { get; set; }
    }
}
