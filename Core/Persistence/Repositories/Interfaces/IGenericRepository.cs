namespace Core.Persistence.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(Guid id);
    Task<List<T>> GetAll();
    Task Add(T entity);
    Task<bool> Exists(Guid id);
    Task Update(T entity);
    Task Delete(T entity);
}