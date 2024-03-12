using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly BrandBusinessRules _brandBusinessRules;

    public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand command, CancellationToken cancellationToken)
    {
        Brand? brand = await _brandRepository.GetAsync(x => x.Id == command.Id);
        _brandBusinessRules.BrandIdShouldExistWhenSelected(brand); //Check brand if exist
        _mapper.Map(command, brand);
        await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenUpdated(brand); //Check brand name duplicate
        Brand updatedBrand = await _brandRepository.UpdateAsync(brand);
        UpdatedBrandResponse? updatedBrandResponse = _mapper.Map<UpdatedBrandResponse>(updatedBrand);
        return updatedBrandResponse;

    }
}
