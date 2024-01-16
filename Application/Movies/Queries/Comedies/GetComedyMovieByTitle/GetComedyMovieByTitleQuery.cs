using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Comedies.GetComedyMovieByTitle
{
    public class GetComedyMovieByTitleQuery : IRequest<List<Movie>>
    {
        public GetComedyMovieByTitleQuery(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
