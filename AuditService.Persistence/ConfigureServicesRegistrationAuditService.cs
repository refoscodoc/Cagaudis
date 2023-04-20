using System.Reflection;
using AuditService.Persistence.DataAccess;
using Core.Persistence;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuditService.Persistence;

public static class ServicesRegistrationAuditService
{
    public static IServiceCollection ConfigureServicesRegistrationAuditService(this IServiceCollection services, IConfiguration configuration)
    {
        // services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddDbContext<AuditableDbContext>();
   
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICarServiceRepository, CarRepository>();
        
        
        // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //builder.Services.AddAutoMapper(typeof(MappingProfile));
        // services.AddMediatR(Assembly.GetExecutingAssembly());
        // builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        // services.AddAuthentication(options =>
        //     {
        //         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //     })
        //     .AddJwtBearer(o =>
        //     {
        //         o.TokenValidationParameters = new TokenValidationParameters
        //         {
        //             ValidateIssuerSigningKey = true,
        //             ValidateIssuer = true,
        //             ValidateAudience = true,
        //             ValidateLifetime = true,
        //             ClockSkew = TimeSpan.Zero,
        //             ValidIssuer = configuration["JwtSettings:Issuer"],
        //             ValidAudience = configuration["JwtSettings:Audience"],
        //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
        //         };
        //     });
        return services;
    }
}