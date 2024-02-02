using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Documentaries.GetDocumentaryMovieByTitle
{
    public class GetDocumentaryMovieByTitleQuery : IRequest<List<Movie>>, IValidate
    {
        public GetDocumentaryMovieByTitleQuery(string title)
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
