using System.Reflection;
using CarsService.Persistence.DataAccess;
using Core;
using Core.Middleware.ApiKeyMiddleware;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAppServices();
builder.Services.PersistenceServices(builder.Configuration);

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(o =>
// {
//     o.Authority = builder.Configuration["IdentityServerAddress"];
//     o.Audience = "MariaApiApp";
//     o.Authority = "https://localhost:5003";
//     o.RequireHttpsMetadata = false;
//     o.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateAudience = false
//     };
// });

// builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddCors(o => o.AddPolicy("Cagaudis", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Cagaudis");
app.UseHttpsRedirection();

// app.UseRouting();

app.UseAuthorization();
// app.UseAuthentication();
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();