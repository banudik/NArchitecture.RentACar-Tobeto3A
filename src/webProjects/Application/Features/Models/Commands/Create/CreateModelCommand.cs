using Application.Features.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommand: IRequest<CreatedModelResponse>
{
    public string Name { get; set; }
    public int BrandId { get; set; }
}
