﻿using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Cars.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Car, CreatedCarResponse>().ReverseMap();
        CreateMap<Car, CreateCarCommand>().ReverseMap();

        CreateMap<Car, DeletedCarResponse>().ReverseMap();
        CreateMap<Car, DeleteCarCommand>().ReverseMap();

        CreateMap<Car, UpdatedCarResponse>().ReverseMap();
        CreateMap<Car, UpdateCarCommand>().ReverseMap();

        CreateMap<Car, GetByIdCarResponse>().ReverseMap();

        CreateMap<Car, GetListCarResponse>().ReverseMap();
    }
}
