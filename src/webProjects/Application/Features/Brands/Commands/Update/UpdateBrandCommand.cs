using Application.Features.Brands.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand:IRequest<UpdatedBrandResponse>, ICacheRemoverRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "brand-list";
}
