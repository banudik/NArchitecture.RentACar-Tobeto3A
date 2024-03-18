using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommand: IRequest<CreatedModelResponse>, IIntervalRequest, ILoggableRequest, ICacheRemoverRequest
{
    public string Name { get; set; }
    public int BrandId { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "model-list";

    public int Interval => 1;
}
