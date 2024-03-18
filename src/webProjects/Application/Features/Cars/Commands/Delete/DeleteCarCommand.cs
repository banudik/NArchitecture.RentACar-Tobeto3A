using Application.Features.Cars.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommand:IRequest<DeletedCarResponse>, ICacheRemoverRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "car-list";
}
