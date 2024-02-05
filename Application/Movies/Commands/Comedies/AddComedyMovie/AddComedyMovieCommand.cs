using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Movie;
using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Comedies.AddComedyMovie
{
    public class AddComedyMovieCommand : IRequest<Comedy>, IValidate
    {
        public ComedyMovieDto NewComedyMovie { get; set; }

        public AddComedyMovieCommand(ComedyMovieDto newComedyMovie)
        {
            NewComedyMovie = newComedyMovie;
        }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(NewComedyMovie, new ComedyMovieDtoValidator());
        }
    }
}
