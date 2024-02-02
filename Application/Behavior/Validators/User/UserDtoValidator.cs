using Application.Dtos.User;
using FluentValidation;

namespace Application.Behavior.Validators.User
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(dto => dto.Username).NotNull().WithMessage("Username cant be NULL")
                .NotEmpty().WithMessage("Guid cant be empty");
            RuleFor(dto => dto.Password).NotNull().WithMessage("Password cant be NULL")
                .NotEmpty().WithMessage("Guid cant be empty");
        }
    }
}
