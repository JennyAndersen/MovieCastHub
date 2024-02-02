using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Movies.Queries.Documentaries.GetDocumentaryMovieByDirector
{
    public class GetDocumentaryMovieByDirectorQueryHandler : IRequestHandler<GetDocumentaryMovieByDirectorQuery, List<Movie>>
    {
        private readonly IMovieRepository _movieRepository;
        public GetDocumentaryMovieByDirectorQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> Handle(GetDocumentaryMovieByDirectorQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetByDirectorAsync(request.Director);

            var documentaryMovies = movies
            .Where(m => m.GetType() == typeof(Documentary))
            .ToList();
            if (documentaryMovies.IsNullOrEmpty())
            {
                throw new EntityNotFoundException("documentary", "director", request.Director);
            }

            return documentaryMovies;
        }
    }
}
