using Domain.Models;
using MediatR;


namespace Application.Users.Querys.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {

    }
}
