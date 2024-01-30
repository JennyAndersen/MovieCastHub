using Application.Dtos.Movie;
using Domain.Models;
using FluentValidation;

namespace Application.Behavior
{
    public abstract class MovieValidator<TDto> : AbstractValidator<TDto>
        where TDto : MovieDto
    {
        protected MovieValidator()
        {
            CommonRules();

            // Additional rules specific to each genre
            ConfigureAdditionalRules();
        }

        private void CommonRules()
        {
            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title cannot exceed 50 characters.");

            RuleFor(dto => dto.Director)
                .NotEmpty().WithMessage("Director is required.")
                .MaximumLength(50).WithMessage("Director cannot exceed 50 characters.");

            RuleFor(dto => dto.Duration)
                .GreaterThanOrEqualTo(0).WithMessage("Duration must be greater than or equal to 0.");

            RuleFor(dto => dto.Rating)
                .InclusiveBetween(0, 10).WithMessage("Rating must be between 0 and 10.");
        }

        protected abstract void ConfigureAdditionalRules();
    }

    public class ComedyMovieDtoValidator : MovieValidator<ComedyMovieDto>
    {
        protected override void ConfigureAdditionalRules()
        {
            RuleFor(dto => dto.HumorStyle)
                .NotEmpty().WithMessage("HumorStyle is required.")
                .MaximumLength(50).WithMessage("HumorStyle cannot exceed 50 characters.");

            RuleFor(dto => dto.FamilyFriendly)
                .NotEmpty().WithMessage("FamilyFriendly is required.");

            RuleFor(dto => dto.ParodyElements)
                .NotEmpty().WithMessage("ParodyElements is required.");
        }
    }

    public class DocumentaryMovieDtoValidator : MovieValidator<DocumentaryMovieDto>
    {
        protected override void ConfigureAdditionalRules()
        {
            RuleFor(dto => dto.HistoricalContext)
                .NotEmpty().WithMessage("HistoricalContext is required.")
                .MaximumLength(100).WithMessage("HistoricalContext cannot exceed 100 characters.");

            RuleFor(dto => dto.RealLifeContext)
                .NotEmpty().WithMessage("RealLifeContext is required.")
                .MaximumLength(100).WithMessage("RealLifeContext cannot exceed 100 characters.");
        }
    }
}
