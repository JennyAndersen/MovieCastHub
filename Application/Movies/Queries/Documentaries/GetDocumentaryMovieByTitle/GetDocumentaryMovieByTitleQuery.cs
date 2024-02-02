using Application.Behavior;
using Application.Behavior.Validators;
using Domain.Models;
using FluentValidation;
using MediatR;
using System.IO;

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
