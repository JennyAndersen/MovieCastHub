using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Movies.Queries.Horrors.GetAllHorror
{
    public class GetAllHorrorMoviesQueryHandler : IRequestHandler<GetAllHorrorMoviesQuery, List<Horror>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllHorrorMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Horror>> Handle(GetAllHorrorMoviesQuery request, CancellationToken cancellationToken)
        {
            List<Horror> allHorrorMovies = await _movieRepository.GetAllHorrorsMoviesAsync();
            if (allHorrorMovies.IsNullOrEmpty())
            {
                throw new EntityNotFoundException("Horror");
            }
            return allHorrorMovies;
        }
    }
}
