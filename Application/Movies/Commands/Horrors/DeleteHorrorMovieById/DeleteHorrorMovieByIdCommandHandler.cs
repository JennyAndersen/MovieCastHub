using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Commands.Horrors.DeleteHorrorMovieById
{
    public class DeleteHorrorMovieByIdCommandHandler : IRequestHandler<DeleteHorrorMovieByIdCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;
        public DeleteHorrorMovieByIdCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<bool> Handle(DeleteHorrorMovieByIdCommand request, CancellationToken cancellationToken)
        {
            // byter namn på variabeln senare - amanda
            Movie comedyMovieToDelete = await _movieRepository.GetByIdAsync(request.MovieId);

            if (comedyMovieToDelete == null)
            {
                return false;
            }

            await _movieRepository.DeleteAsync(request.MovieId);
            return true;
        }
    }
}
