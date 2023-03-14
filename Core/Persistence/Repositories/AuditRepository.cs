using Core.DataAccess;
using Core.Entities;
using Core.Persistence.Repositories.Interfaces;
using GenericPersistence.Repositories;

namespace Core.Persistence.Repositories;

public class AudiRepository : GenericRepository<AuditModel>, IAuditServiceRepository
{
    private readonly GenericDbContext _context;
    
    public AudiRepository(GenericDbContext context) : base(context)
    {
        _context = context;
    }
}