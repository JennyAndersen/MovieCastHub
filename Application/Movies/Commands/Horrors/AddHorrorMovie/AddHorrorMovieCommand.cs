using Application.Dtos.Movie;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
