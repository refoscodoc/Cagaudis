using GenericPersistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ConfigurePersistenceServices
{
    public static IServiceCollection PersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var serverVersion = new MySqlServerVersion(new Version(10, 11, 2));
        services.AddDbContext<GenericDbContext>(o =>
            o.UseMySql(configuration["ConnectionString"], serverVersion));
        return services;
    }
}