using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backend.Context;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace backend.Infraestructure.Repositories;

public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;
    public readonly AppDbContext Db;
    public readonly DbSet<TEntity> DbSet;
    private bool _disposed;

    protected Repository(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
        Db = contextFactory.CreateDbContext();
        DbSet = Db.Set<TEntity>();
    }

    public virtual async Task Delete(int id)
    {
        var entity = await Select(id);
        entity.IsDeleted = true;
        await Update(entity);
    }

    public async Task PhisicalDelete(int id)
    {
        var entity = await DbSet.FindAsync(id);
        DbSet.Remove(entity);
        await SaveChanges();
    }

    public virtual async Task<bool> Exists(int id)
    {
        return await DbSet
            .AsNoTrackingWithIdentityResolution()
            .AnyAsync(e => e.Id == id && (e.IsDeleted == false || e.IsDeleted == null));
    }

    public virtual async Task<List<TEntity>> List()
    {
        return await DbSet
            .AsNoTrackingWithIdentityResolution()
            .Where(c => c.IsDeleted == false || c.IsDeleted == null)
            .ToListAsync();
    }

    public virtual async Task<Pagination<TEntity>> PaginationList(int offset, int limit, bool desc = false)
    {
        var skip = (offset - 1) * limit;
        var query = DbSet
            .AsNoTrackingWithIdentityResolution()
            .Where(c => c.IsDeleted == false || c.IsDeleted == null);
        var rowCount = await query.CountAsync();
        var pagination = new Pagination<TEntity>
        {
            Offset = offset,
            TotalPages = (int) Math.Ceiling((double) rowCount / limit),
            List = desc
                ? await query.OrderByDescending(p => p.Id).Skip(skip).Take(limit).ToListAsync()
                : await query.OrderBy(p => p.Id).Skip(skip).Take(limit).ToListAsync(),
            TotalItems = rowCount
        };
        return pagination;
    }
    
    public virtual async Task<List<TEntity>> DescendingList()
    {
        return await DbSet
            .AsNoTrackingWithIdentityResolution()
            .Where(c => c.IsDeleted == false || c.IsDeleted == null)
            .OrderByDescending(c => c.Id)
            .ToListAsync();
    }

    public virtual async Task<TEntity> Save(TEntity entity)
    {
        try
        {
            Db.ChangeTracker.Clear();

            if (entity.Id > 0)
                await Update(entity);
            else
                await Insert(entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return entity;
    }

    public virtual async Task<int> SaveChanges()
    {
        var ret = await Db.SaveChangesAsync();
        Db.ChangeTracker.Clear();
        return ret;
    }

    public virtual async Task<TEntity> Select(int id)
    {
        return await DbSet
            .Where(c => c.Id == id && (c.IsDeleted == false || c.IsDeleted == null))
            .FirstOrDefaultAsync();
    }

    public virtual async Task<TEntity> GetById(int id)
    {
        return await DbSet
            .Where(c => c.Id == id && (c.IsDeleted == false || c.IsDeleted == null))
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync();
    }

    public virtual async Task<IQueryable<TEntity>> Search()
    {
        return DbSet
            .AsNoTrackingWithIdentityResolution()
            .Where(c => c.IsDeleted == false || c.IsDeleted == null);
    }

    public virtual async Task<List<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = DbSet
            .AsNoTrackingWithIdentityResolution()
            .Where(c => c.IsDeleted == false || c.IsDeleted == null)
            .AsQueryable();

        // Adiciona os includes
        if (includes != null && includes.Any())
            foreach (var include in includes)
                query = query.Include(include);
        
        if (predicate != null)
            query = query.Where(predicate);
        
        return await query.ToListAsync();
    }

    public virtual async Task<TEntity> SearchUnique(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = DbSet
            .AsNoTrackingWithIdentityResolution()
            .Where(c => c.IsDeleted == false || c.IsDeleted == null)
            .AsQueryable();

        // Adiciona os includes
        if (includes != null && includes.Any())
            foreach (var include in includes)
                query = query.Include(include);
        
        if (predicate != null)
            query = query.Where(predicate);
        
        return await query.FirstOrDefaultAsync();
    }

    public virtual async Task<TEntity> ExecuteSingleSql(string sql)
    {
        var connection = Db.Database.GetDbConnection();
        var result = await connection.QueryAsync<TEntity>(sql);
        var ret = result.FirstOrDefault();
        await connection.CloseAsync();
        return ret;
    }

    public virtual async Task<List<TEntity>> ExecuteListSql(string sql)
    {
        var connection = Db.Database.GetDbConnection();
        var result = await connection.QueryAsync<TEntity>(sql);
        var ret = result.ToList();
        await connection.CloseAsync();
        return ret;
    }

    public DbConnection GetConnection()
    {
        return Db.Database.GetDbConnection();
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        try
        {
            Db.ChangeTracker.Clear();
            var oldEntity = await DbSet.Where(c => c.Id == entity.Id)
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync();
            
            if (oldEntity is null)
                throw new Exception("Entity not found");
            
            entity.CreatedAt ??= oldEntity.CreatedAt;
            entity.CreatingUserId ??= oldEntity.CreatingUserId;
            entity.IsDeleted ??= false;
            entity.UpdatedAt = DateTime.Now;
            DbSet.Update(entity);
            await SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return entity;
    }

    public virtual async Task<TEntity> Insert(TEntity entity)
    {
        try
        {
            entity.CreatedAt = DateTime.Now;
            await DbSet.AddAsync(entity);
            await SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet
            .AsNoTrackingWithIdentityResolution()
            .Where(c => c.IsDeleted == false || c.IsDeleted == null)
            .Where(predicate)
            .ToListAsync();
    }


    


}
