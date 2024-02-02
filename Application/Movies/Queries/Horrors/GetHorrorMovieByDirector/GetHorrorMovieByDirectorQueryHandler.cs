﻿using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Movies.Queries.Horrors.GetHorrorMovieByDirector
{
    public class GetHorrorMovieByDirectorQueryHandler : IRequestHandler<GetHorrorMovieByDirectorQuery, List<Movie>>
    {
        private readonly IMovieRepository _movieRepository;
        public GetHorrorMovieByDirectorQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> Handle(GetHorrorMovieByDirectorQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetByDirectorAsync(request.Director);

            var horrorMovies = movies
            .Where(m => m.GetType() == typeof(Horror))
            .ToList();
            if (horrorMovies.IsNullOrEmpty())
            {
                throw new EntityNotFoundException("Horror", "Director", request.Director);
            }

            return horrorMovies;
        }
    }
}
