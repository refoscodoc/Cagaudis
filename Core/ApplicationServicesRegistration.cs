using System.Reflection;
using Core.Persistence;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Interfaces;
using GenericPersistence;
using GenericPersistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICarServiceRepository, CarRepository>();
        services.AddScoped<IAuditServiceRepository, AudiRepository>();
        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();
        return services;
    }
}