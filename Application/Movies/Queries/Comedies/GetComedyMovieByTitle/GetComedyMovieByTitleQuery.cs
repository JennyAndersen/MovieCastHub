using Application.Dtos.Movie;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Queries.Comedies.GetComedyMovieByTitle
{
    public class GetComedyMovieByTitleQuery : IRequest<Movie>
    {
        public GetComedyMovieByTitleQuery(string title)
        {
             Title = title; 
        }

        public string Title { get; }
    }
}
