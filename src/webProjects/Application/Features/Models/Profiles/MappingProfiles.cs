using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

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
        CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
    }
}
