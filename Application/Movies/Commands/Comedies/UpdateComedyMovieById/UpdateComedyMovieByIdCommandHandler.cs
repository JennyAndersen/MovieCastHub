using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Commands.Comedies.UpdateComedyMovieById
{
    public class UpdateComedyMovieByIdCommandHandler : IRequestHandler<UpdateComedyMovieByIdCommand, Comedy>
    {
        private readonly IMovieRepository _movieRepository;

        public UpdateComedyMovieByIdCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Comedy> Handle(UpdateComedyMovieByIdCommand request, CancellationToken cancellationToken)
        {
            var movieToUpdate = await _movieRepository.GetByIdAsync(request.Id) as Comedy
       ?? throw new Exception($"Movie with ID {request.Id} not found.");

            movieToUpdate.Rating = request.UpdatedComedyMovie.Rating;

            await _movieRepository.UpdateByIdAsync(movieToUpdate);

            return movieToUpdate;
        }
    }
}
