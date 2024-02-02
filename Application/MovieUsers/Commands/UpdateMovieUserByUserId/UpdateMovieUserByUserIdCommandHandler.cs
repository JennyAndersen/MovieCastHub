using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.MovieUsers.Commands.UpdateMovieUserByUserId
{
    public class UpdateMovieUserByUserIdCommandHandler : IRequestHandler<UpdateMovieUserByUserIdCommand, bool>
    {
        private readonly IMovieUserRepository _movieUserRepository;

        public UpdateMovieUserByUserIdCommandHandler(IMovieUserRepository movieUserRepository)
        {
            _movieUserRepository = movieUserRepository;
        }

        public async Task<bool> Handle(UpdateMovieUserByUserIdCommand request, CancellationToken cancellationToken)
        {
            UserMovie movieUser = await _movieUserRepository.GetMovieUserByIdAsync(request.UserMovieId) ?? throw new EntityNotFoundException("UserMovie", request.UserMovieId);

            movieUser.UserRating = request.NewUserRating;

            await _movieUserRepository.UpdateMovieUserAsync(movieUser);

            return true;
        }
    }
}
