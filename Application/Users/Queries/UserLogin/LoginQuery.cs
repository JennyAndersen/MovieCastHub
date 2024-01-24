using MediatR;


namespace Application.Users.Queries.UserLogin
{
    public class LoginQuery : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginQuery(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
