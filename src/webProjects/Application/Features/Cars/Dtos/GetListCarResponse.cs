using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Dtos;

public class GetListCarResponse:IResponse
{
    public int ModelId { get; set; }
    public string ModelName { get; set; }
    public string BrandName { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }  // 1- Available 2- Rented 3-Under Maitenance
    public double DailyPrice { get; set; }

    public DateTime CreatedDate { get; set; }
}
