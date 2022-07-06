global using Microsoft.EntityFrameworkCore;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ParkingSpaceService>();
builder.Services.AddScoped<ParkingSessionService>();
builder.Services.AddScoped<ParkingSpotService>();
builder.Services.AddScoped<ParkingUsersService>();
builder.Services.AddScoped<ParkingSensorService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7236/",
                                              "https://localhost:7236/api/",
                                              "https://localhost:7236/api/Parking/allParkingSpots",
                                              "http://127.0.0.1:5500",
                                              "https://localhost:7236/api/Parking/parkingSessionsPerDate")
                          .AllowAnyMethod()
                          .WithHeaders("content-type");
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();

