using Application.Dtos.MovieUser;
using MediatR;

namespace Application.MovieUsers.Commands.AddMovieUser
{
    public class AddMovieUserCommand : IRequest<bool>
    {
        public AddMovieUserCommand(MovieUserDto newMovieUser)
        {
            NewMovieUser = newMovieUser;
        }

        public MovieUserDto NewMovieUser { get; }
    }
}
