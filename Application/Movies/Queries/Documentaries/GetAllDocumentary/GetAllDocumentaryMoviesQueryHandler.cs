using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Movies.Queries.Documentaries.GetAllDocumentary
{
    public class GetAllDocumentaryMoviesQueryHandler : IRequestHandler<GetAllDocumentaryMoviesQuery, List<Documentary>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllDocumentaryMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Documentary>> Handle(GetAllDocumentaryMoviesQuery request, CancellationToken cancellationToken)
        {
            List<Documentary> allDocumentaryMovies = await _movieRepository.GetAllDocumentaryMoviesAsync();
            if (allDocumentaryMovies.IsNullOrEmpty())
            {
                throw new EntityNotFoundException("documentary");
            }
            return allDocumentaryMovies;
        }
    }
}
