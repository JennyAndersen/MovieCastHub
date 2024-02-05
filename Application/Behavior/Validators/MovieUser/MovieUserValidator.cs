using Application.Dtos.MovieUser;
using FluentValidation;

namespace Application.Behavior.Validators.MovieUser
{
    public class MovieUserValidator : AbstractValidator<MovieUserDto>
    {
        public MovieUserValidator()
        {
            RuleFor(guid => guid).NotNull().WithMessage("Guid cant be NULL")
                .NotEmpty().WithMessage("Guid cant be empty");
            RuleFor(value => value).NotEmpty().WithMessage("Input is required.");
        }
    }
}
