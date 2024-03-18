using Application.Features.Models.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Models.Queries.GetListPagination;

public class GetListPaginationModelQuery : IRequest<ModelListModel>/*, ICachableRequest*/
{
    public PageRequest PageRequest { get; set; }

    //public bool BypassCache { get; }

    //public string CacheKey => "brand-list";

    //public TimeSpan? SlidingExpiration { get; }
}
