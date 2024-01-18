using Domain.Models;
using MediatR;

namespace Application.Movies.Queries.Horrors.GetAllHorror
{
    public class GetAllHorrorMoviesQuery : IRequest<List<Horror>>
    {
    }
}
