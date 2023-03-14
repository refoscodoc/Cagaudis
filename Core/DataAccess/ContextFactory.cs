using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Core.DataAccess
{
    internal class GenericDbContextFactory : IDesignTimeDbContextFactory<GenericDbContext>
    {
        public GenericDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<GenericDbContext> dbContextOptionsBuilder =
                new();
            dbContextOptionsBuilder.UseMySql(new MySqlServerVersion(new Version(10, 11, 2)));
            return new GenericDbContext(dbContextOptionsBuilder.Options);
        }
    }
}