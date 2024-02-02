using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Commands.Horrors.UpdateHorrorMovie
{
    public class UpdateHorrorMovieByIdCommandHandler : IRequestHandler<UpdateHorrorMovieByIdCommand, Horror>
    {
        private readonly IMovieRepository _movieRepository;

        public UpdateHorrorMovieByIdCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Horror> Handle(UpdateHorrorMovieByIdCommand request, CancellationToken cancellationToken)
        {
            var movieToUpdate = await _movieRepository.GetByIdAsync(request.Id) as Horror
                ?? throw new EntityNotFoundException("Horror", request.Id);

            movieToUpdate.Rating = request.UpdatedHorrorMovie.Rating;

            await _movieRepository.UpdateByIdAsync(movieToUpdate);

            return movieToUpdate;
        }
    }
}
