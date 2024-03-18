using Application.Features.Brands.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQuery : IRequest<List<GetListBrandResponse>>, ICachableRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public bool BypassCache { get; }

    public string CacheKey => "brand-list";

    public TimeSpan? SlidingExpiration { get; }
}
