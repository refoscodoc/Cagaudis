using Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace UsersService.Persistence.DataAccess;

public class UsersDbContext : GenericDbContext
{
    public UsersDbContext(DbContextOptions<GenericDbContext> options) : base(options)
    {
    }
}