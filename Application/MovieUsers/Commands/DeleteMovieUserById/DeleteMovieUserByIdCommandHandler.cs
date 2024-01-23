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
            await _repository.DeleteByIdAsync(request.UserMovieId);
            return true;
        }
    }
}
