using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Documentaries.GetAllDocumentary
{
    public class GetAllDocumentaryMoviesQuery : IRequest<List<Documentary>> { }
}
