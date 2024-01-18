using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Horrors.AddHorrorMovie
{
    public class AddHorrorMovieCommand : IRequest<Horror>
    {
        public AddHorrorMovieCommand(HorrorMovieDto newHorrorMovie)
        {
            NewHorrorMovie = newHorrorMovie;
        }
        public HorrorMovieDto NewHorrorMovie { get; set; }
    }
}
