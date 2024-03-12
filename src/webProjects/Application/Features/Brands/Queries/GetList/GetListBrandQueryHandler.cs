using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, List<GetListBrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<List<GetListBrandResponse>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
    {
        List<Brand> brands = await _brandRepository.GetAllAsync();
        List<GetListBrandResponse> getListBrandResponses = _mapper.Map<List<GetListBrandResponse>>(brands);
        return getListBrandResponses;
    }
}

