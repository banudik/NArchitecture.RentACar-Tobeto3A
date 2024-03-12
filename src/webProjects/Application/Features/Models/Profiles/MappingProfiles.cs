using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, CreatedModelResponse>().ReverseMap();
        CreateMap<Model, CreateModelCommand>().ReverseMap();

        CreateMap<Model, DeletedModelResponse>().ReverseMap();
        CreateMap<Model, DeleteModelCommand>().ReverseMap();

        CreateMap<Model, UpdatedModelResponse>().ReverseMap();
        CreateMap<Model, UpdateModelCommand>().ReverseMap();

        CreateMap<Model, GetByIdModelResponse>().ReverseMap();

        CreateMap<Model, GetListModelResponse>().ReverseMap();
    }
}
