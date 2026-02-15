using Twit.DataAccess.Entities;

namespace Twit.DataAccess;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    T? GetById(int id);
    T? GetById(Guid externalId);
    T Save(T entity);
    bool Delete(T entity);
    bool Delete(Guid externalId);
    bool Delete(int id);
}