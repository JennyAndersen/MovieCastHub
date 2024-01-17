using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Documentaries.GetDocumentaryMovieByTitle
{
    public class GetDocumentaryMovieByTitleQuery : IRequest<List<Movie>>
    {
        public GetDocumentaryMovieByTitleQuery(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
