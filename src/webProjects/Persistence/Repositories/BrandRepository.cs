using Application.Services.Repositories;
using Core.Persistence.Repositories.EntityFramework;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BrandRepository : EfRepositoryBase<Brand, int, BaseDbContext>, IBrandRepository
{
    public BrandRepository(BaseDbContext context) : base(context)
    {
    }
}
