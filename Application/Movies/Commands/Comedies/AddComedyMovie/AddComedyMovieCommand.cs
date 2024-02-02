using Application.Behavior;
using Application.Dtos.Movie;
using Domain.Models;
using FluentValidation;
using MediatR;
using System.IO;

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
