using Core.DataAccess;
using Core.Entities;
using Core.Persistence.Repositories.Interfaces;

namespace Core.Persistence.Repositories;

public class CarRepository : GenericRepository<CarModel>, ICarServiceRepository
{
    private readonly GenericDbContext _context;
    public CarRepository(GenericDbContext context) : base(context)
    {
        _context = context;
    }
}