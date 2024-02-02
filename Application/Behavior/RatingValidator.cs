using Application.Dtos.Movie;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behavior
{
    public class RatingValidator : AbstractValidator<UpdateMovieDto>
    {
        public RatingValidator()
        {
            RuleFor(dto => dto.Rating).NotEmpty().WithMessage("Rating is required.");
        }
    }
}
