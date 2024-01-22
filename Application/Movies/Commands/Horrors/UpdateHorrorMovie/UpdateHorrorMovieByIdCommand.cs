using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Horrors.UpdateHorrorMovie
{
    public class UpdateHorrorMovieByIdCommand : IRequest<Horror>
    {
        public UpdateHorrorMovieByIdCommand(UpdateMovieDto updatedHorrorMovie, Guid id)
        {
            UpdatedHorrorMovie = updatedHorrorMovie;
            Id = id;
        }

        public UpdateMovieDto UpdatedHorrorMovie { get; }
        public Guid Id { get; }
    }


}
