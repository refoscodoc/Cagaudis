using System.Reflection;
using Core.Persistence;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersService.Persistence.DataAccess;

namespace UsersService.Persistence;

public static class ServicesRegistrationUsersService
{
    public static IServiceCollection ConfigureServicesRegistrationUsersService(this IServiceCollection services, IConfiguration configuration)
    {
        // services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
   
        services.AddDbContext<UsersDbContext>();
        
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