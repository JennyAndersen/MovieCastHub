using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Comedies.UpdateComedyMovieById
{
    public class UpdateComedyMovieByIdCommand : IRequest<Comedy>
    {
        public UpdateComedyMovieByIdCommand(ComedyMovieDto updatedComedyMovie, Guid id)
        {
            UpdatedComedyMovie = updatedComedyMovie;
            Id = id;
        }

        public ComedyMovieDto UpdatedComedyMovie { get; }
        public Guid Id { get; }
    }
}
