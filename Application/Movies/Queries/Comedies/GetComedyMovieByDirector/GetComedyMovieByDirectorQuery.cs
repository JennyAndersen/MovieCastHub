using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
