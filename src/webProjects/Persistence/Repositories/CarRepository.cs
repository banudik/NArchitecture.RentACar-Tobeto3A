using Application.Services.Repositories;
using Core.Persistence.Repositories.EntityFramework;
using Domain.Entities;
using Persistence.Contexts;
namespace Persistence.Repositories;

public class CarRepository : EfRepositoryBase<Car, int, BaseDbContext>, ICarRepository
{
    public CarRepository(BaseDbContext context) : base(context)
    {
    }
}
