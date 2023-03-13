using Core.Entities;
using Core.Persistence.Repositories.Interfaces;
using GenericPersistence.DataAccess;
using GenericPersistence.Repositories;

namespace Core.Persistence.Repositories;

public class AudiRepository : GenericRepository<AuditModel>, IAuditServiceRepository
{
    private readonly GenericDbContext _context;
    
    public AudiRepository(GenericDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<AuditModel> AddAudit(AuditModel audit)
    {
        return await _context.Add(audit);
    }
}