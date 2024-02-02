using Application.Dtos.Movie;
using FluentValidation;

namespace Application.Behavior.Validators.Movie
{
    public class RatingValidator : AbstractValidator<UpdateMovieDto>
    {
        public RatingValidator()
        {
            RuleFor(dto => dto.Rating).NotEmpty().WithMessage("Rating is required.");
        }
    }
}
