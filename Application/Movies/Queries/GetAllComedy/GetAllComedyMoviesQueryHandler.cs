﻿using Domain.Models;
using Infrastructure;
using MediatR;

namespace Application.Movies.Queries.GetAllComedy
{
    public class GetAllComedyMoviesQueryHandler : IRequestHandler<GetAllComedyMoviesQuery, List<Comedy>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllComedyMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        async Task<List<Comedy>> IRequestHandler<GetAllComedyMoviesQuery, List<Comedy>>.Handle(GetAllComedyMoviesQuery request, CancellationToken cancellationToken)
        {
            List<Comedy> allComedyMovies = await _movieRepository.GetAllComedyMoviesQuery();
            return allComedyMovies;
        }
    }
}