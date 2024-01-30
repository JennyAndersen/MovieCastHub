namespace Application.Dtos.Movie
{
    public class DocumentaryMovieDto : MovieDto
    {
        public required string HistoricalContext { get; set; }
        public required string RealLifeContext { get; set; }
    }
}
