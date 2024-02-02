using Application.Behavior;
using Domain.Models;
using FluentValidation;
using MediatR;
using System.IO;

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
