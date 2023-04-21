using System.Reflection;
using Core.Contracts;
using Core.Persistence;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Interfaces;
using Core.Services;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICarServiceRepository, CarRepository>();
        services.AddScoped<IAuditServiceRepository, AudiRepository>();
        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();
        
        services.AddScoped<IAuditServices, AuditServices>();
        return services;
    }
}