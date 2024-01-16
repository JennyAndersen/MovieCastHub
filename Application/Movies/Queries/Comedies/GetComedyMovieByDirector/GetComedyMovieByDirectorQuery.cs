using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Comedies.GetComedyMovieByDirector
{
    public class GetComedyMovieByDirectorQuery : IRequest<List<Movie>>
    {
        public GetComedyMovieByDirectorQuery(string director)
        {
            Director = director;
        }

        public string Director { get; }
    }
}
