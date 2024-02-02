using Application.Behavior;
using Domain.Models;
using FluentValidation;
using MediatR;

namespace Application.Movies.Queries.Documentaries.GetDocumentaryMovieByDirector
{
    public class GetDocumentaryMovieByDirectorQuery : IRequest<List<Movie>>, IValidate
    {
        public GetDocumentaryMovieByDirectorQuery(string director)
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
