using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Dtos;

public class DeletedBrandResponse:IResponse
{
    public int Id { get; set; }
}
