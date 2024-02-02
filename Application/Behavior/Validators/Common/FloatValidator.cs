using FluentValidation;

namespace Application.Behavior.Validators.Common
{
    public class FloatValidator : AbstractValidator<float>
    {
        public FloatValidator()
        {
            RuleFor(value => value).NotEmpty().WithMessage("Input is required.");
        }
    }
}
