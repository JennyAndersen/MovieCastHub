using Application.Movies.Commands.Comedies.AddComedyMovie;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Commands.Horrors.AddHorrorMovie
{
    public class AddHorrorMovieCommandHandler : IRequestHandler<AddHorrorMovieCommand, Horror>
    {
        private readonly IMovieRepository _movieRepository;
        public AddHorrorMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Horror> Handle(AddHorrorMovieCommand request, CancellationToken cancellationToken)
        {
            Horror horrorMovieToCreate = new()
            {
                MovieId = Guid.NewGuid(),
                Title = request.NewHorrorMovie.Title,
                Director = request.NewHorrorMovie.Director,
                Duration = request.NewHorrorMovie.Duration,
                Rating = request.NewHorrorMovie.Rating,
                ScaryLevel = request.NewHorrorMovie.ScaryLevel,
                SupernaturalElements = request.NewHorrorMovie.SupernaturalElements,
                GoreLevel = request.NewHorrorMovie.GoreLevel
            };

            await _movieRepository.AddMovieAsync(horrorMovieToCreate);
            return horrorMovieToCreate;
        }
    }
}
