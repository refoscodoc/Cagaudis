using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace UsersService.Persistence;

public static class UserServiceServicesRegistration
{
    public static IServiceCollection ConfigureFilesApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}