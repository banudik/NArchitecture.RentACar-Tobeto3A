using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        CreateMap<Brand, DeletedBrandResponse>().ReverseMap();
        CreateMap<Brand, DeleteBrandCommand>().ReverseMap();

        CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();
        CreateMap<Brand, UpdateBrandCommand>().ReverseMap();

        CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();

        CreateMap<Brand, GetListBrandResponse>().ReverseMap();
    }
}
