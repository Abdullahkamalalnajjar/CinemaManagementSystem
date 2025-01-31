using CinemaManagementSystem.Core.Features.Users.Queries.Response;
using CinemaManagementSystem.Core.Wrappers;
using MediatR;

namespace CinemaManagementSystem.Core.Features.Users.Queries.Model;

public class GetUserPaginatedListQuery : IRequest<PaginatedResult<GetUserPaginatedListResponse>>
{
    public GetUserPaginatedListQuery()
    {

    }
    public GetUserPaginatedListQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}