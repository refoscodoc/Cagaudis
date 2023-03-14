using Core;
using UsersService.Persistence.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAppServices();
builder.Services.PersistenceServices(builder.Configuration);

// builder.Services.AddDbContext<UsersDbContext>();
builder.Services.AddHttpContextAccessor();

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

app.MapControllers();

app.Run();