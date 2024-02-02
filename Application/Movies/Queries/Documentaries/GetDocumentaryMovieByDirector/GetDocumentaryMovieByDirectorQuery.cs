using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
using Domain.Models;
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
