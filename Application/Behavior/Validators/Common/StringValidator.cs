using FluentValidation;

namespace Application.Behavior.Validators.Common
{
    public class StringValidator : AbstractValidator<string>
    {
        public StringValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("is required.")
                .MaximumLength(50).WithMessage("cannot exceed 50 characters.");
        }
    }
}
