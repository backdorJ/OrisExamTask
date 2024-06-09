using DefaultProject.DAL.PostgreSQL;
using DefaultProject.Domain;
using DefaultProject.Domain.Abstractions;
using DefaultProject.Middlewares;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .WriteTo.File($"log_{DateTime.Now:dd-MM-yyyy}.txt", rollingInterval: RollingInterval.Minute)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IDbContext, EfContext>(options =>
    options.UseNpgsql("User ID=postgres;Password=root;Host=localhost;Port=5432;Database=WeatherForecastDb;"));
builder.Services.AddTransient<WriteDateQueryMiddleware>();

builder.Services.AddCore();

var app = builder.Build();

app.UseMiddleware<WriteDateQueryMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();