using CustomBlog.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Api.Application.Interfaces.Repositories;

public interface IGenericRepository<TEntity> where TEntity: BaseEntity
{
    Task<int> AddAsync(TEntity entity);
    int Add(TEntity entity);
    Task<int> AddAsync(IEnumerable<TEntity> entities);
    int Add(IEnumerable<TEntity> entities);

    Task<int> UpdateAsync(TEntity entity);
    int Update(TEntity entity);

    Task<int> DeleteAsync(TEntity entity);
    int Delete(TEntity entity);
    Task<int> DeleteAsync(Guid id);
    int Delete(Guid id);
    Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);
    bool DeleteRange(Expression<Func<TEntity, bool>> predicate);

    Task<int> AddOrUpdateAsync(TEntity entity);
    int AddOrUpdate(TEntity entity);
    IQueryable<TEntity> AsQueryable();
    Task<List<TEntity>> GelAll(bool noTracking = true);


}
