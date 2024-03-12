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

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommandHandler:IRequestHandler<UpdateCarCommand, UpdatedCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;
    private readonly CarBusinessRules _carBusinessRules;

    public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _carBusinessRules = carBusinessRules;
    }

    public async Task<UpdatedCarResponse> Handle(UpdateCarCommand command, CancellationToken cancellationToken)
    {
        Car? car = await _carRepository.GetAsync(x=>x.Id == command.Id);
        _carBusinessRules.CarIdShouldExistWhenSelected(car);
        _carBusinessRules.CarNameCanNotBeDuplicatedWhenUpdated(car);
        _mapper.Map(command, car);
        Car updatedCar = await _carRepository.UpdateAsync(car);
        UpdatedCarResponse updatedCarResponse = _mapper.Map<UpdatedCarResponse>(updatedCar);
        return updatedCarResponse;
    }
}
