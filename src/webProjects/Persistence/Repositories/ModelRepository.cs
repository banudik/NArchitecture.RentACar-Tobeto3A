﻿using Application.Services.Repositories;
using Core.Persistence.Repositories.EntityFramework;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ModelRepository : EfRepositoryBase<Model, int, BaseDbContext>, IModelRepository
{
    public ModelRepository(BaseDbContext context) : base(context)
    {
    }
}