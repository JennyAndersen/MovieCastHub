using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.MovieUsers.Commands.AddMovieUser
{
    public class AddMovieUserCommandHandler : IRequestHandler<AddMovieUserCommand, bool>
    {
        private readonly IMovieUserRepository _repository;

        public AddMovieUserCommandHandler(IMovieUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(AddMovieUserCommand request, CancellationToken cancellationToken)
        {
            UserMovie movieUser = new()
            {
                UserId = request.NewMovieUser.UserId,
                MovieId = request.NewMovieUser.MovieId,
            };

            return await _repository.AddMovieUserAsync(movieUser);
        }
    }
}
