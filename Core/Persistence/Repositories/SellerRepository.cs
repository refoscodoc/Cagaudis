using Core.DataAccess;
using Core.Entities;
using Core.Persistence.Repositories.Interfaces;
using GenericPersistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Repositories;

public class SellerRepository : GenericRepository<SellerModel>, ISellerRepository
{
    private readonly GenericDbContext _context;
    public SellerRepository(GenericDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<SellerModel>> GetAllSellers()
    {
        return await _context.Sellers.ToListAsync();
    }
}