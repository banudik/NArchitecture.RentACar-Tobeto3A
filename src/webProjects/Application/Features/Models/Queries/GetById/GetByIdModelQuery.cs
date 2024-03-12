using Application.Features.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetById;

public class GetByIdModelQuery: IRequest<GetByIdModelResponse>
{
    public int Id { get; set; }

}
