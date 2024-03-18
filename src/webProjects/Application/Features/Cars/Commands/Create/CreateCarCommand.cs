using Application.Features.Cars.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommand:IRequest<CreatedCarResponse>, IIntervalRequest, ILoggableRequest, ICacheRemoverRequest
{
    public int ModelId { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }
    public double DailyPrice { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "car-list";

    public int Interval => 1;
}
