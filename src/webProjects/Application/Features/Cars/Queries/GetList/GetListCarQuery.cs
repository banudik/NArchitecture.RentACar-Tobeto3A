using Application.Features.Cars.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetList;

public class GetListCarQuery: IRequest<List<GetListCarResponse>>, ICachableRequest
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }
    public double DailyPrice { get; set; }

    public bool BypassCache { get; }

    public string CacheKey => "car-list";

    public TimeSpan? SlidingExpiration { get; }
}
