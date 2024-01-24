using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Horrors.GetHorrorMovieByTitle
{
    public class GetHorrorMovieByTitleQuery : IRequest<List<Movie>>
    {
        public GetHorrorMovieByTitleQuery(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
