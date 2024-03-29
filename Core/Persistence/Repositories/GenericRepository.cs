using Core.DataAccess;
using Core.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly GenericDbContext _context;

    public GenericRepository(GenericDbContext context)
    {
        _context = context;
    }

    public async Task<T> Get(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }
    
    public async Task<List<T>> GetAllPaginated(int pagination, int page)
    {
        // TODO implement proper pagination 
        return await _context.Set<T>().Take(pagination).ToListAsync();
    }

    public async Task<List<T>> GetAllByManufacturerPaginated()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<List<T>> GetAllByModelPaginated()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Exists(Guid id)
    {
        return  _context.Set<T>().FindAsync(id).IsCompletedSuccessfully;
    }

    public async Task Update(T entity)
    { 
        _context.Set<T>().Update(entity);
        await  _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}