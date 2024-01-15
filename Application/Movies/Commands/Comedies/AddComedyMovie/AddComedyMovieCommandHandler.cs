using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Commands.Comedies.AddComedyMovie
{
    public class AddComedyMovieCommandHandler : IRequestHandler<AddComedyMovieCommand, Comedy>
    {
        private readonly IMovieRepository _movieRepository;
        public AddComedyMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Comedy> Handle(AddComedyMovieCommand request, CancellationToken cancellationToken)
        {
            Comedy comedyMovieToCreate = new()
            {
                MovieId = Guid.NewGuid(),
                Title = request.NewComedyMovie.Title,
                Director = request.NewComedyMovie.Director,
                Duration = request.NewComedyMovie.Duration,
                Rating = request.NewComedyMovie.Rating,
                HumorStyle = request.NewComedyMovie.HumorStyle,
                FamilyFriendly = request.NewComedyMovie.FamilyFriendly,
                ParodyElements = request.NewComedyMovie.ParodyElements
            };

            await _movieRepository.AddMovieAsync(comedyMovieToCreate);
            return comedyMovieToCreate;
        }
    }
}
