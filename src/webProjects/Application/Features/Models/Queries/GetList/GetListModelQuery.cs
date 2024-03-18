using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelQuery: IRequest<List<GetListModelResponse>>, ICachableRequest
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string BrandName { get; set; }
    public string Name { get; set; }

    public bool BypassCache { get; }

    public string CacheKey => "model-list";

    public TimeSpan? SlidingExpiration { get; }

}
