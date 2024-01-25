using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

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

            var DocumentaryMovies = movies
            .Where(m => m.GetType() == typeof(Documentary))
            .ToList();

            return DocumentaryMovies;
        }
    }
}
