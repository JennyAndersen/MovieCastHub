using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Comedies.GetAllComedy
{
    public class GetAllComedyMoviesQuery : IRequest<List<Comedy>>
    {
    }
}
