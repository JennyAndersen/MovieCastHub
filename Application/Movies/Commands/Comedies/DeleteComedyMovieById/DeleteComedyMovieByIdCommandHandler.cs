using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Commands.Comedies.DeleteComedyMovieById
{
    public class DeleteComedyMovieByIdCommandHandler : IRequestHandler<DeleteComedyMovieByIdCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;
        public DeleteComedyMovieByIdCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<bool> Handle(DeleteComedyMovieByIdCommand request, CancellationToken cancellationToken)
        {
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
