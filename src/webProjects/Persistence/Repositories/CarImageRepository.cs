﻿using Application.Services.Repositories;
using Core.Persistence.Repositories.EntityFramework;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CarImageRepository: EfRepositoryBase<CarImage, int, BaseDbContext>, ICarImageRepository
{
    public CarImageRepository(BaseDbContext context) : base(context)
    {
    }
}
