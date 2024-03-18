using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Dtos;

public class DeletedModelResponse:IResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}
