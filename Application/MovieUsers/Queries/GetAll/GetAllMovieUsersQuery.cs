using Domain.Models;
using MediatR;

namespace Application.MovieUsers.Queries.GetAll
{
    public class GetAllMovieUsersQuery : IRequest<List<UserMovie>>
    {
    }
}
