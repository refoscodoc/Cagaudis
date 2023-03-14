using Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Storage;

namespace Core;

public static class ConfigurePersistenceServices
{
    public static IServiceCollection PersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var serverVersion = new MySqlServerVersion(new Version(10, 11, 2));
        services.AddDbContext<GenericDbContext>(o =>
            o.UseMySql(configuration["ConnectionStrings:DataAccessMySqlProvider"], serverVersion),
            // optionsLifetime: ServiceLifetime.Singleton);
            optionsLifetime: ServiceLifetime.Transient);
        
        services.AddDbContextFactory<GenericDbContext>(o => 
                o.UseMySql(configuration["ConnectionStrings:DataAccessMySqlProvider"], serverVersion), 
            ServiceLifetime.Singleton);  
        
        return services;
    }
}