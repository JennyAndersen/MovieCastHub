using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Documentaries.GetDocumentaryMovieByDirector
{
    public class GetDocumentaryMovieByDirectorQuery : IRequest<List<Movie>>
    {
        public GetDocumentaryMovieByDirectorQuery(string director)
        {
            Director = director;
        }

        public string Director { get; }
    }
}
