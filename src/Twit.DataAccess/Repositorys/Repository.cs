using Microsoft.EntityFrameworkCore;
using Twit.DataAccess.Context;
using Twit.DataAccess.Entities;

namespace Twit.DataAccess;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly TwitDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(TwitDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IQueryable<T> GetAll() => _dbSet.AsQueryable();

    public T? GetById(int id) => _dbSet.FirstOrDefault(x => x.Id == id);

    public T? GetById(Guid externalId) => _dbSet.FirstOrDefault(x => x.ExternalId == externalId);

    public T Save(T entity)
    {
        if (entity.Id == 0)
        {
            // Новая сущность
            entity.ExternalId = Guid.NewGuid();
            entity.CreationTime = DateTime.UtcNow;
            entity.ModificationTime = DateTime.UtcNow;
            _dbSet.Add(entity);
        }
        else
        {
            // Существующая сущность
            entity.ModificationTime = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        _context.SaveChanges();
        return entity;
    }

    public bool Delete(T entity)
    {
        _dbSet.Remove(entity);
        return _context.SaveChanges() > 0;
    }

    public bool Delete(Guid externalId)
    {
        var entity = GetById(externalId);
        return entity != null && Delete(entity);
    }

    public bool Delete(int id)
    {
        var entity = GetById(id);
        return entity != null && Delete(entity);
    }
}