using Amazon.Runtime.Internal.Util;
using Application.Features.Cars.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarQuery:IRequest<GetByIdCarResponse>, ICachableRequest
{
    public int Id { get; set; }
    public bool BypassCache { get; }

    public string CacheKey => "car-list";

    public TimeSpan? SlidingExpiration { get; }
}
