using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Dtos;

public class CreatedModelResponse:IResponse
{
    public int BrandId { get; set; }
    public string Name { get; set; }
}
