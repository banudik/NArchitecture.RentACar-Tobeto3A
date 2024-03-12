using Application.Features.Brands.Dtos;
using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommandHandler:IRequestHandler<CreateCarCommand, CreatedCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CreatedCarResponse> Handle(CreateCarCommand command, CancellationToken cancellationToken)
    {
        Car mappedCar = _mapper.Map<Car>(command);
        Car createdCar = await _carRepository.AddAsync(mappedCar);
        CreatedCarResponse createdCarResponse = _mapper.Map<CreatedCarResponse>(createdCar);
        return createdCarResponse;
    }
}
