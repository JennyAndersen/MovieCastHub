using Application.Dtos.User;
using FluentValidation;

namespace Application.Behavior.Validators.User
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(dto => dto.Password).NotNull().WithMessage("Password cant be NULL")
                .NotEmpty().WithMessage("Guid cant be empty");
        }
    }
}
