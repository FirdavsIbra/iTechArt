using iTechArt.Database.DbContexts;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IPoliceParsers;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Repository.Mappers;
using iTechArt.Repository.Repositories;
using iTechArt.Serivce.Services;
using iTechArt.Service.Helpers;
using iTechArt.Service.Parsers;
using iTechArt.Service.Parsers.PoliceParser;
using iTechArt.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IPupilRepository, PupilRepository>();
builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IPoliceRepository, PoliceRepository>();
builder.Services.AddScoped<IMedStaffRepository, MedStaffRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IGroceryRepository, GroceryRepository>();

builder.Services.AddScoped<ITotalStatisticsService, TotalStatisticsService>();
builder.Services.AddScoped<IAirportsService, AirportService>();
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IGroceryService, GroceryService>();
builder.Services.AddScoped<IMedStaffService, MedStaffService>();
builder.Services.AddScoped<IPoliceService, PoliceService>();
builder.Services.AddScoped<IPupilService, PupilService>();

// Parser Services
builder.Services.AddScoped<IExcelParser, ExcelParser>();
builder.Services.AddScoped<IXmlParser, XmlParser>();
builder.Services.AddScoped<ICsvParser, CsvParser>();
builder.Services.AddScoped<IMedStaffParser, MedStaffParser>();
builder.Services.AddScoped<IGroceryParsers, GroceryParsers>();
builder.Services.AddScoped<IAirportParsers, AirportParser>();
builder.Services.AddScoped<IPupilParsers, PupilParsers>();
builder.Services.AddScoped<IStudentParsers, StudentParsers>();


builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("iTechArtConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

EnvironmentHelper.WebRootPath = app.Services.GetService<IWebHostEnvironment>().WebRootPath;

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
