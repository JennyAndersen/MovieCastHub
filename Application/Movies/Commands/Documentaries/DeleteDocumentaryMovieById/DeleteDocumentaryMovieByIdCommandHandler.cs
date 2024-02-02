using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Commands.Documentaries.DeleteDocumentaryMovieById
{
    public class DeleteDocumentaryMovieByIdCommandHandler : IRequestHandler<DeleteDocumentaryMovieByIdCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;
        public DeleteDocumentaryMovieByIdCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<bool> Handle(DeleteDocumentaryMovieByIdCommand request, CancellationToken cancellationToken)
        {
            Movie documentaryMovieToDelete = await _movieRepository.GetByIdAsync(request.MovieId) ?? throw new EntityNotFoundException("Documentary", request.MovieId);

            if (documentaryMovieToDelete == null)
            {
                return false;
            }

            await _movieRepository.DeleteAsync(request.MovieId);
            return true;
        }
    }
}
