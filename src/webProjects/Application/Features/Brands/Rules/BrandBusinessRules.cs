using Application.Services.Repositories;
using Azure.Core;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules : BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public void BrandIdShouldExistWhenSelected(Brand? brand)
    {
        if (brand == null)
            throw new Exception("Brand with this Id does not exist!");
    }

    public async Task BrandNameCanNotBeDuplicatedWhenUpdated(Brand brand)
    {
        Brand? result = await _brandRepository.GetAsync(x => x.Id != brand.Id && x.Name.ToLower() == brand.Name.ToLower());
        if (result != null)
            throw new Exception("Brand name already exist");
    }

}
