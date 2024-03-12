using Application.Services.Repositories;
using Core.Application.Rules;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Rules;

public class CarBusinessRules:BaseBusinessRules
{
    private readonly ICarRepository _carRepository;

    public CarBusinessRules(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public void CarIdShouldExistWhenSelected(Car? car)
    {
        if (car == null)
            throw new Exception("Car with this Id does not exist!");
    }

    public async Task CarNameCanNotBeDuplicatedWhenUpdated(Car car)
    {
        Car? result = await _carRepository.GetAsync(x => x.Id != car.Id && x.Plate.ToLower() == car.Plate.ToLower());
        if (result != null)
            throw new Exception("Car plate already exist");
    }
}
