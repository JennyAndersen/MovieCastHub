using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Queries.Documentaries.GetAllDocumentary
{
    public class GetAllDocumentaryMoviesQueryHandler : IRequestHandler<GetAllDocumentaryMoviesQuery, List<Documentary>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllDocumentaryMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        async Task<List<Documentary>> IRequestHandler<GetAllDocumentaryMoviesQuery, List<Documentary>>.Handle(GetAllDocumentaryMoviesQuery request, CancellationToken cancellationToken)
        {
            List<Documentary> allDocumentaryMovies = await _movieRepository.GetAllDocumentaryMoviesAsync();
            return allDocumentaryMovies;
        }
    }
}
