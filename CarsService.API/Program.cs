using System.Reflection;
using CarsService.Persistence.DataAccess;
using Core.Middleware.ApiKeyMiddleware;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var sqlConnectionString = builder.Configuration.GetConnectionString("DataAccessMySqlProvider");
var serverVersion = new MySqlServerVersion(new Version(10, 6, 7));

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

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddCors(o => o.AddPolicy("Cagaudis", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddDbContext<CarsDbContext>(options =>
    options.UseMySql(
        sqlConnectionString, serverVersion)
);

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