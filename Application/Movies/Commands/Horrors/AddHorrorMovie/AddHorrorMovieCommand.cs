using Application.Behavior;
using Application.Dtos.Movie;
using Domain.Models;
using FluentValidation;
using MediatR;

namespace Application.Movies.Commands.Horrors.AddHorrorMovie
{
    public class AddHorrorMovieCommand : IRequest<Horror>, IValidate
    {
        public AddHorrorMovieCommand(HorrorMovieDto newHorrorMovie)
        {
            NewHorrorMovie = newHorrorMovie;
        }
        public HorrorMovieDto NewHorrorMovie { get; set; }

        public void Validate()
        {
            var validator = new HorrorMovieDtoValidator();
            var validationResult = validator.Validate(NewHorrorMovie);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
