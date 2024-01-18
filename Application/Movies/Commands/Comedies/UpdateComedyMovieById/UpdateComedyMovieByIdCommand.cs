using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Comedies.UpdateComedyMovieById
{
    public class UpdateComedyMovieByIdCommand : IRequest<Comedy>
    {
        public UpdateComedyMovieByIdCommand(UpdateMovieDto updatedComedyMovie, Guid id)
        {
            UpdatedComedyMovie = updatedComedyMovie;
            Id = id;
        }

        public UpdateMovieDto UpdatedComedyMovie { get; }
        public Guid Id { get; }
    }
}
