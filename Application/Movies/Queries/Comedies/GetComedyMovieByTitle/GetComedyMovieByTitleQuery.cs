using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Comedies.GetComedyMovieByTitle
{
    public class GetComedyMovieByTitleQuery : IRequest<List<Movie>>, IValidate
    {
        public GetComedyMovieByTitleQuery(string title)
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
