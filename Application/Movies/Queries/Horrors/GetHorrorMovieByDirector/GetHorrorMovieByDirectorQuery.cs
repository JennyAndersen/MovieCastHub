using Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Movies.Queries.Horrors.GetHorrorMovieByDirector
{
    public class GetHorrorMovieByDirectorQuery : IRequest<List<Movie>>
    {
        public GetHorrorMovieByDirectorQuery(string director)
        {
            Director = director;
        }

        public string Director { get; }
    }
}
