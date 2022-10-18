using iTechArt.Data.DbContexts;
using iTechArt.Data.IRepositories;
using iTechArt.Data.Repositories;
using iTechArt.Service.Interfaces;
using iTechArt.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IAirportsService, AirportService>();
builder.Services.AddSingleton<IGroceryService, GroceryService>();

builder.Services.AddSingleton<IStudentsService, StudentsService>();
builder.Services.AddSingleton<IPupilService, PupilService>();
builder.Services.AddSingleton<IMedStaffService, MedStaffService>();
builder.Services.AddSingleton<IPoliceService, PoliceService>();
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<ITotalStatisticsService, TotalStatisticsService>();

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("iTechArtConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
