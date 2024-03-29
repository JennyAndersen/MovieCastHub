﻿namespace Application.Dtos.Movie
{
    public class MovieDto
    {
        public required string Title { get; set; }
        public required string Director { get; set; }
        public int Duration { get; set; }
        public float Rating { get; set; }
    }
}
