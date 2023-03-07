using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}