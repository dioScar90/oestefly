using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Infraestructure.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task Delete(int id);
    Task PhisicalDelete(int id);
    Task<TEntity> Select(int id);
    Task<TEntity> GetById(int id);
    Task<List<TEntity>> List();
    Task<Pagination<TEntity>> PaginationList(int offset, int limit, bool desc);
    Task<List<TEntity>> DescendingList();
    Task<TEntity> Save(TEntity entity);
    Task<bool> Exists(int id);
    Task<int> SaveChanges();
    Task<IQueryable<TEntity>> Search();
    Task<TEntity> SearchUnique(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    Task<List<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    Task<TEntity> ExecuteSingleSql(string sql);
    Task<List<TEntity>> ExecuteListSql(string sql);
    DbConnection GetConnection();
}
