﻿using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Movies.Queries.Comedies.GetAllComedy
{
    public class GetAllComedyMoviesQueryHandler : IRequestHandler<GetAllComedyMoviesQuery, List<Comedy>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllComedyMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Comedy>> Handle(GetAllComedyMoviesQuery request, CancellationToken cancellationToken)
        {
            List<Comedy> allComedyMovies = await _movieRepository.GetAllComedyMoviesAsync();
            if (allComedyMovies.IsNullOrEmpty())
            {
                throw new EntityNotFoundException("Comedy");
            }
            return allComedyMovies;
        }
    }
}
