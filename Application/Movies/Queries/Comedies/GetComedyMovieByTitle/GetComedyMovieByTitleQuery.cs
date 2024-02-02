using Application.Behavior;
using Application.Behavior.Validators;
using Application.Dtos.Movie;
using Domain.Models;
using FluentValidation;
using MediatR;
using System.IO;

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
