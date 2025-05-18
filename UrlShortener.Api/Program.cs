using Microsoft.EntityFrameworkCore;
using UrlShortener.Api;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Services;
using UrlShortener.Infrastructure.Data;
using UrlShortener.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); // Enables OpenAPI support
builder.Services.AddSwaggerGen(); 

builder.Services.AddDbContext<UrlDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUrlRepository, UrlRepository>();
builder.Services.AddScoped<IUrlService, UrlService>();

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers(); 

app.Run();
