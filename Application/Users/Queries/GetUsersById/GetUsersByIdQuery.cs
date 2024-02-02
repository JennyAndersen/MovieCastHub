using Application.Behavior;
using Application.Behavior.Validators;
using Domain.Models;
using MediatR;


namespace Application.Users.Querys.GetUsersById
{
    public class GetUsersByIdQuery : IRequest<User>, IValidate
    {
        public Guid UserId { get; }

        public GetUsersByIdQuery(Guid userId)
        {
            UserId = userId;
        }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(UserId, new GuidValidator());
        }
    }
}
