using Domain.Models;
using MediatR;


namespace Application.Users.Querys.GetUsersById
{
    public class GetUsersByIdQuery : IRequest<User>
    {
        public Guid UserId { get; }

        public GetUsersByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
