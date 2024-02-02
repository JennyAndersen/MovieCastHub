using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Comedies.GetComedyMovieByDirector
{
    public class GetComedyMovieByDirectorQuery : IRequest<List<Movie>>, IValidate
    {
        public GetComedyMovieByDirectorQuery(string director)
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
