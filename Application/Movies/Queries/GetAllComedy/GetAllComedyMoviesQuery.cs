using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.GetAllComedy
{
    public class GetAllComedyMoviesQuery : IRequest<List<Comedy>>
    {
    }
}
