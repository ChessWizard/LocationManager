using LocationManager.API.Services.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;
using LocationManager.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// JSON veri alma konfigürasyonu
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS ile bilinmeyen client'lara karþý servis güvenliði
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
                                              policy.AllowAnyMethod()
                                                    .AllowAnyHeader()
                                                    .AllowCredentials()
                                                    .SetIsOriginAllowed(origin => true)));

builder.Services.AddScoped<ILocationManager, LocationManager.API.Services.LocationManager>();
builder.Services.AddScoped<HttpClient>();

var app = builder.Build();

app.UseCors();

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
