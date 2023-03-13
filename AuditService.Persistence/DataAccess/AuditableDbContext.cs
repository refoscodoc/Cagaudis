using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuditService.Persistence.DataAccess;

public class AuditableDbContext : GenericDbContext
{
    public AuditableDbContext(DbContextOptions<GenericDbContext> options) : base(options)
    {
    }
}