using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarsService.Persistence;

public static class CarServiceServicesRegistration
{
    public static IServiceCollection ConfigureFilesApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}