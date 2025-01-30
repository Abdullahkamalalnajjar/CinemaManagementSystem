using CinemaManagementSystem.Core.Bases;
using CinemaManagementSystem.Core.Features.Theaters.Queries.Results;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Theaters.Queries.Models
{
    public class GetTheaterListQuery : IRequest<Response<List<GetTheaterListResponse>>>
    {

    }
}
