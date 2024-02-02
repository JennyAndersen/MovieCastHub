using FluentValidation;

namespace Application.Behavior.Validators
{
    public static class ValidationHelper
    {
        public static void ValidateAndThrow<T>(T entity, AbstractValidator<T> validator)
        {
            var validationResult = validator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
