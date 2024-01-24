using MediatR;

namespace Application.Movies.Commands.Documentaries.DeleteDocumentaryMovieById
{
    public class DeleteDocumentaryMovieByIdCommand : IRequest<bool>
    {
        public DeleteDocumentaryMovieByIdCommand(Guid movieId)
        {
            MovieId = movieId;
        }

        public Guid MovieId { get; }
    }
}
