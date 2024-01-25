using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.MovieUsers.Queries.GetAll
{
    public class GetAllMovieUsersQueryHandler : IRequestHandler<GetAllMovieUsersQuery, List<UserMovie>>
    {
        private readonly IMovieUserRepository _movieUserRepository;

        public GetAllMovieUsersQueryHandler(IMovieUserRepository movieUserRepository)
        {
            _movieUserRepository = movieUserRepository;
        }
        public async Task<List<UserMovie>> Handle(GetAllMovieUsersQuery request, CancellationToken cancellationToken)
        {
            List<UserMovie> allMovieUsers = await _movieUserRepository.GetAllMovieUsersAsync();

            return allMovieUsers;
        }
    }
}
