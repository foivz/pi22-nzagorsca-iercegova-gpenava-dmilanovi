global using Microsoft.EntityFrameworkCore;
using PodaciIzBaze.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ParkingSpaceService>();
builder.Services.AddScoped<ParkingSessionService>();
builder.Services.AddScoped<ParkingSpotService>();
builder.Services.AddScoped<ParkingUsersService>();
builder.Services.AddScoped<ParkingSensorService>();
var app = builder.Build();

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
