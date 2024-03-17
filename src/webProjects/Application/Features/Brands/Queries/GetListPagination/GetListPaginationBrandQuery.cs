using Application.Features.Brands.Models;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetListPagination;

public class GetListPaginationBrandQuery : IRequest<BrandListModel>/*, ICachableRequest*/
{
    public PageRequest PageRequest { get; set; }

    //public bool BypassCache { get; }

    //public string CacheKey => "brand-list";

    //public TimeSpan? SlidingExpiration { get; }
}
