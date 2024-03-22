using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CarImageService;

public class CarImageBusinessRules
{
    private readonly ICarImageRepository _carImageRepository;

    public CarImageBusinessRules(ICarImageRepository carImageRepository)
    {
        _carImageRepository = carImageRepository;
    }


    public async Task<List<CarImage>> CheckIfCarImageNull(int carId)
    {
        try
        {
            string path = @"\Images\default.jpg";
            var result = await _carImageRepository.GetAllAsync(predicate: c => c.CarId == carId);
            if (result == null)
            {
                List<CarImage> carImages = new List<CarImage>();
                carImages.Add(new CarImage { CarId = carId, ImagePath = path });
            }
        }
        catch (Exception e)
        {
            throw new BusinessException(e.Message);
        }
        return await _carImageRepository.GetAllAsync(c => c.CarId == carId);
    }


    public Task CheckIfImageLimit(int carId)
    {
        var carImageCount = _carImageRepository.GetAllAsync(predicate: c => c.CarId == carId).Result.Count();
        if (carImageCount >= 5)
        {
            throw new BusinessException("You exceeded the limit");
        }
        return Task.CompletedTask;
    }


    public Task CheckIfCarImageFormat(IFormFile formFile)
    {
        string fileExtension = Path.GetExtension(formFile.FileName).ToLower();
        if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
        {
            throw new BusinessException("you can only add files with .jpg,.jpeg and .png extension");
        }
        return Task.CompletedTask;
    }



    public async Task CarImageIdShouldExistsWhenSelected(int id)
    {
        CarImage? result = await _carImageRepository.GetAsync(c => c.Id == id);
        if (result is null) throw new BusinessException("Car Image Not Exists");
    }

    public async Task CarImageCarIdShouldExistsWhenSelected(int carId)
    {
        CarImage? result = await _carImageRepository.GetAsync(c => c.CarId == carId);
        if (result is null) throw new BusinessException("CarId Not Exists");
    }
}
