using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
