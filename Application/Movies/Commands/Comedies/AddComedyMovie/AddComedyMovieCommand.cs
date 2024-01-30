using Application.Behavior;
using Application.Dtos.Movie;
using AutoMapper;
using Domain.Models;
using FluentValidation;
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
            var validator = new ComedyMovieDtoValidator();
            var validationResult = validator.Validate(NewComedyMovie);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
