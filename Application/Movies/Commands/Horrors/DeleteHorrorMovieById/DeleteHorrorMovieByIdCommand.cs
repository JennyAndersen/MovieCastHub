using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Commands.Horrors.DeleteHorrorMovieById
{
    public class DeleteHorrorMovieByIdCommand : IRequest<bool>
    {
        public DeleteHorrorMovieByIdCommand(Guid movieId)
        {
            MovieId = movieId;
        }

        public Guid MovieId { get; }
    }
}
