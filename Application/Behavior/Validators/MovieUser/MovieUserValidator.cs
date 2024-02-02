using Application.Dtos.MovieUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
