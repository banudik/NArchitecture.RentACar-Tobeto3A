using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Dynamic = Core.Persistence.Dynamic.Dynamic;


namespace Core.Persistence.Repositories;

public interface IAsyncRepository<TEntity, TEntityId> : IQuery<TEntity>
    where TEntity : BaseEntity<TEntityId>
{
    Task<IPaginate<TEntity>> GetListPaginateAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderby = null,
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                            int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default, bool withDeleted = false);

    Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
       int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default, bool withDeleted = false);

    Task<List<TEntity>> GetAllAsync
        (Expression<Func<TEntity, bool>> predicate = null,
         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,bool withDeleted = false);

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false);

    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity,bool permanent = false);
    

}
