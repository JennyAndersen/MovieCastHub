using Application.Behavior;
using Application.Behavior.Validators;
using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Horrors.GetHorrorMovieByTitle
{
    public class GetHorrorMovieByTitleQuery : IRequest<List<Movie>>, IValidate
    {
        public GetHorrorMovieByTitleQuery(string title)
        {
            Title = title;
        }

        public string Title { get; }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(Title, new StringValidator());
        }
    }
}
