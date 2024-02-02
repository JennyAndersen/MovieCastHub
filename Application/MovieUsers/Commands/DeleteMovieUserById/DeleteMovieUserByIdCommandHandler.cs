using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.MovieUsers.Commands.DeleteMovieUserById
{
    public class DeleteMovieUserByIdCommandHandler : IRequestHandler<DeleteMovieUserByIdCommand, bool>
    {
        private readonly IMovieUserRepository _repository;
        public DeleteMovieUserByIdCommandHandler(IMovieUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteMovieUserByIdCommand request, CancellationToken cancellationToken)
        {
            UserMovie userMovie = await _repository.GetMovieUserByIdAsync(request.UserMovieId) ?? throw new EntityNotFoundException("MovUserMovieieUser", request.UserMovieId);
            if (userMovie == null)
            {
                return false;
            }

            await _repository.DeleteByIdAsync(request.UserMovieId);
            return true;
        }
    }
}
