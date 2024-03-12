using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommandHandler:IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly BrandBusinessRules _brandBusinessRules;

    public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand command, CancellationToken cancellationToken)
    {
        Brand? brand = await _brandRepository.GetAsync(x => x.Id == command.Id);
        _brandBusinessRules.BrandIdShouldExistWhenSelected(brand);
        _mapper.Map(command,brand);
        Brand deletedBrand = await _brandRepository.DeleteAsync(brand);
        DeletedBrandResponse? deletedBrandResponse = _mapper.Map<DeletedBrandResponse>(deletedBrand);
        return deletedBrandResponse;
    }
}
