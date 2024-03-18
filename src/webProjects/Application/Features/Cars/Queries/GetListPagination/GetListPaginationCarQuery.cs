using Application.Features.Cars.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Cars.Queries.GetListPagination;

public class GetListPaginationCarQuery : IRequest<CarListModel>/*, ICachableRequest*/
{
    public PageRequest PageRequest { get; set; }

    //public bool BypassCache { get; }

    //public string CacheKey => "brand-list";

    //public TimeSpan? SlidingExpiration { get; }
}
