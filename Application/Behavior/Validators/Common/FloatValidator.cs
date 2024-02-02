using Application.Dtos.Movie;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
