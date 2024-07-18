using Microsoft.EntityFrameworkCore;
using OutPatientDashboard.Service.Data;
using OutPatientDashboard.Service.Managers;
using OutPatientDashboard.Service.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<ApplicationDBContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnString"));
});

// DI 
builder.Services.AddScoped<ICustomLogger, CustomLogger>();
builder.Services.AddScoped<IApplicationDBContext, ApplicationDBContext>();
builder.Services.AddScoped<IPatientManager, PatientManager>();
builder.Services.AddScoped<IPhysicianManager, PhysicianManager>();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
