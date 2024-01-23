using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Commands.Documentaries.AddDocumentaryMovie
{
    public class AddDocumentaryMovieCommandHandler : IRequestHandler<AddDocumentaryMovieCommand, Documentary>
    {
        private readonly IMovieRepository _movieRepository;
        public AddDocumentaryMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Documentary> Handle(AddDocumentaryMovieCommand request, CancellationToken cancellationToken)
        {
            Documentary documentaryMovieToCreate = new()
            {
                MovieId = Guid.NewGuid(),
                Title = request.NewDocumentaryMovie.Title,
                Director = request.NewDocumentaryMovie.Director,
                Duration = request.NewDocumentaryMovie.Duration,
                Rating = request.NewDocumentaryMovie.Rating,
                HistoricalContext = request.NewDocumentaryMovie.HistoricalContext,
                RealLifeContext = request.NewDocumentaryMovie.RealLifeContext
            };

            await _movieRepository.AddMovieAsync(documentaryMovieToCreate);
            return documentaryMovieToCreate;
        }
    }
}
