using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
using Application.Behavior.Validators.Movie;
using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Horrors.UpdateHorrorMovie
{
    public class UpdateHorrorMovieByIdCommand : IRequest<Horror>, IValidate
    {
        public UpdateHorrorMovieByIdCommand(UpdateMovieDto updatedHorrorMovie, Guid id)
        {
            UpdatedHorrorMovie = updatedHorrorMovie;
            Id = id;
        }

        public UpdateMovieDto UpdatedHorrorMovie { get; }
        public Guid Id { get; }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(UpdatedHorrorMovie, new RatingValidator());
            ValidationHelper.ValidateAndThrow(Id, new GuidValidator());
        }
    }
}
