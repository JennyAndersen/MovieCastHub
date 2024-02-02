using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
