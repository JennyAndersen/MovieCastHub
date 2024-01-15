using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Comedies.AddComedyMovie
{
    public class AddComedyMovieCommand : IRequest<Comedy>
    {
        public AddComedyMovieCommand(ComedyMovieDto newComedyMovie)
        {
            NewComedyMovie = newComedyMovie;
        }
        public ComedyMovieDto NewComedyMovie { get; set; }
    }
}
