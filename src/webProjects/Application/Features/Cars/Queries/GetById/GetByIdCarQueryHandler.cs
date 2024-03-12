using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, GetByIdCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;
    private readonly CarBusinessRules _carBusinessRules;

    public GetByIdCarQueryHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _carBusinessRules = carBusinessRules;
    }

    public async Task<GetByIdCarResponse> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
    {
        Car? car = await _carRepository.GetAsync(x => x.Id == request.Id);
        _carBusinessRules.CarIdShouldExistWhenSelected(car);

        GetByIdCarResponse? getByIdCarResponse = _mapper.Map<GetByIdCarResponse>(car);
        return getByIdCarResponse;
    }
}

