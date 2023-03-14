using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarsService.Persistence.DataAccess;

public class CarsDbContext : GenericDbContext
{
    public CarsDbContext(DbContextOptions<GenericDbContext> options) : base(options) { }
}