using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Repositories.Interfaces;

public class ManufacturerRepository : GenericRepository<ManufacturerModel>, IManufacturerRepository
{
    private readonly GenericDbContext _context;

    public ManufacturerRepository(GenericDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<ManufacturerModel>> GetAllSellers()
    {
        return await _context.Manufacturers.ToListAsync();
    }
}