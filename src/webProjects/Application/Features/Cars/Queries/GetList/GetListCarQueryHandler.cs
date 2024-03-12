using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetList;

public class GetListCarQueryHandler: IRequestHandler<GetListCarQuery, List<GetListCarResponse>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;
    private readonly CarBusinessRules _carBusinessRules;

    public GetListCarQueryHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _carBusinessRules = carBusinessRules;
    }

    public async Task<List<GetListCarResponse>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
    {
        List<Car> cars = await _carRepository.GetAllAsync();
        List<GetListCarResponse> getListCarResponses = _mapper.Map<List<GetListCarResponse>>(cars);
        return getListCarResponses;
    }
}

