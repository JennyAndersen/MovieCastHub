using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Commands.Documentaries.UpdateDocumentaryMovieById
{
    public class UpdateDocumentaryMovieByIdCommandHandler : IRequestHandler<UpdateDocumentaryMovieByIdCommand, Documentary>
    {
        private readonly IMovieRepository _movieRepository;

        public UpdateDocumentaryMovieByIdCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Documentary> Handle(UpdateDocumentaryMovieByIdCommand request, CancellationToken cancellationToken)
        {
            var movieToUpdate = await _movieRepository.GetByIdAsync(request.Id) as Documentary
       ?? throw new Exception($"Movie with ID {request.Id} not found.");

            movieToUpdate.Rating = request.UpdatedDocumentaryMovie.Rating;

            await _movieRepository.UpdateByIdAsync(movieToUpdate);

            return movieToUpdate;
        }
    }
}
