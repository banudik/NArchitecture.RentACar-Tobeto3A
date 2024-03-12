using Application.Features.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommand: IRequest<UpdatedModelResponse>
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Name { get; set; }
}
