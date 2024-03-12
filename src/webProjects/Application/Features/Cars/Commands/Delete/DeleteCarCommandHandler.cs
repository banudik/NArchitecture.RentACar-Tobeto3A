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

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommandHandler:IRequestHandler<DeleteCarCommand, DeletedCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;
    private readonly CarBusinessRules _carBusinessRules;

    public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _carBusinessRules = carBusinessRules;
    }

    public async Task<DeletedCarResponse> Handle(DeleteCarCommand command, CancellationToken cancellationToken)
    {
        Car? car = await _carRepository.GetAsync(x=>x.Id == command.Id);
        _carBusinessRules.CarIdShouldExistWhenSelected(car);
        Car deletedCar = await _carRepository.DeleteAsync(car);
        DeletedCarResponse deletedCarResponse = _mapper.Map<DeletedCarResponse>(deletedCar);
        return deletedCarResponse;
    }
}
