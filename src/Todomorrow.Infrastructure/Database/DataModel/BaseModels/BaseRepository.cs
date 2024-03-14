using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.BaseModels
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly DbSet<T> _database;
    protected readonly AppDbContext _dbContext;

    public BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _database = dbContext.Set<T>();
    }

    //TODO centralizar o código para criar ID e CreatedAt
    public async Task<T> Add(T obj)
    {
        obj.Id = obj.Id == Guid.Empty ? Guid.NewGuid() : obj.Id;
        obj.CreatedAt = DateTimeOffset.UtcNow;

        _ = await _database.AddAsync(obj);

        return obj;
    }

    public async Task<List<T>> AddRange(List<T> obj)
    {
        foreach (T item in obj)
        {
            item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
            item.CreatedAt = item.CreatedAt != DateTimeOffset.MinValue ? item.CreatedAt : DateTimeOffset.UtcNow;
            item.UpdatedAt = item.UpdatedAt != DateTimeOffset.MinValue ? item.UpdatedAt : DateTimeOffset.UtcNow;
        }

        await _database.AddRangeAsync(obj);
        _ = await _dbContext.SaveChangesAsync();

        return obj;
    }

    public async Task<T> Create(T obj)
    {
        obj.Id = obj.Id == Guid.Empty ? Guid.NewGuid() : obj.Id;
        obj.CreatedAt = DateTimeOffset.UtcNow;

        _ = await _dbContext.AddAsync(obj);
        _ = await _dbContext.SaveChangesAsync();

        return obj;
    }

    public async Task<T> DeleteFromContext(T obj)
    {
        _ = _database.Remove(obj);
        return await Task.FromResult(obj);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _database.ToListAsync();
    }

    public async Task<T> GetById(Guid id)
    {
        return await _database.SingleOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task SaveChangesAsync()
    {
        _ = await _dbContext.SaveChangesAsync();
    }

    public async Task<T> Update(T obj)
    {
        obj.UpdatedAt = DateTimeOffset.UtcNow;

        _ = _dbContext.Update(obj);
        _ = await _dbContext.SaveChangesAsync();

        return obj;
    }
}
}

