using Application.Behavior;
using Application.Behavior.Validators;
using Domain.Models;
using FluentValidation;
using MediatR;

namespace Application.Movies.Queries.Horrors.GetHorrorMovieByDirector
{
    public class GetHorrorMovieByDirectorQuery : IRequest<List<Movie>>, IValidate
    {
        public GetHorrorMovieByDirectorQuery(string director)
        {
            Director = director;
        }

        public string Director { get; }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(Director, new StringValidator());
        }
    }
}
