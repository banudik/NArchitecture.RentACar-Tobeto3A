using Application.Features.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelQuery: IRequest<List<GetListModelResponse>>
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string BrandName { get; set; }
    public string Name { get; set; }
}
