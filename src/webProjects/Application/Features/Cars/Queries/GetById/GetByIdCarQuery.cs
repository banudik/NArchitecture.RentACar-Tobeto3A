using Application.Features.Cars.Dtos;
using MediatR;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarQuery:IRequest<GetByIdCarResponse>
{
    public int Id { get; set; }
}
