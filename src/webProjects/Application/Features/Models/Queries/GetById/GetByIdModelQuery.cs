using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetById;

public class GetByIdModelQuery: IRequest<GetByIdModelResponse>, ICachableRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }

    public string CacheKey => "model-list";

    public TimeSpan? SlidingExpiration { get; }

}
