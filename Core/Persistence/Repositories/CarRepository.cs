using Core.Entities;
using Core.Persistence.Repositories.Interfaces;
using GenericPersistence.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GenericPersistence.Repositories;

public class CarRepository : GenericRepository<CarModel>, ICarServiceRepository
{
    private readonly GenericDbContext _context;
    public CarRepository(GenericDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<CarModel>> GetAllCars()
    {
        return await _context.Cars.ToListAsync();
    }
}