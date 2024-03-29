using System.Reflection;
using AuditService.Persistence;
using AuditService.Persistence.DataAccess;
using Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAppServices();
builder.Services.PersistenceServices(builder.Configuration);
builder.Services.ConfigureServicesRegistrationAuditService(builder.Configuration);

// var sqlConnectionString = builder.Configuration.GetConnectionString("DataAccessMySqlProvider");
// var serverVersion = new MySqlServerVersion(new Version(10, 11, 2));

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(o => o.AddPolicy("Cagaudis", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

// builder.Services.AddDbContext<AuditableDbContext>(options =>
//     options.UseMySql(
//         sqlConnectionString, serverVersion)
// );

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

using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<AuditableDbContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();
}

app.UseCors("Cagaudis");
app.UseHttpsRedirection();

// app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();