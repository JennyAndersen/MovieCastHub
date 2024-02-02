namespace Application.Dtos.Movie
{
    public class HorrorMovieDto : MovieDto
    {
        public int ScaryLevel { get; set; }
        public bool SupernaturalElements { get; set; }
        public int GoreLevel { get; set; }

    }
}
