using Application.Behavior;
using Application.Behavior.Validators;
using Domain.Models;
using MediatR;


namespace Application.Users.Queries.UserLogin
{
    public class LoginQuery : IRequest<string>, IValidate
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginQuery(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(UserName, new StringValidator());
            ValidationHelper.ValidateAndThrow(Password, new StringValidator());
        }
    }
}
