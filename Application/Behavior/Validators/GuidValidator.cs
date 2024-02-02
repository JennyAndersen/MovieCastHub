using FluentValidation;

namespace Application.Behavior.Validators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            Validate();
        }

        public void Validate()
        {
            RuleFor(guid => guid).NotNull().WithMessage("Guid cant be NULL")
                .NotEmpty().WithMessage("Guid cant be empty");
        }
    }
}
