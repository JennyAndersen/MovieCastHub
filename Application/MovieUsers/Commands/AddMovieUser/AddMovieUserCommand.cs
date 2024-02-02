using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.MovieUser;
using Application.Dtos.MovieUser;
using MediatR;

namespace Application.MovieUsers.Commands.AddMovieUser
{
    public class AddMovieUserCommand : IRequest<bool>, IValidate
    {
        public AddMovieUserCommand(MovieUserDto newMovieUser)
        {
            NewMovieUser = newMovieUser;
        }

        public MovieUserDto NewMovieUser { get; }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(NewMovieUser, new MovieUserValidator());
        }
    }
}
