using Microsoft.EntityFrameworkCore;
using Person_Api_Interest.Models;
using Person_Api_Interest.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Implementing repository pattern via implementation of Icrud, objects and objectRepositories
builder.Services.AddScoped<Icrud<Person>, PersonRepository>();
builder.Services.AddScoped<Icrud<Interest>, InterestRepository>();
builder.Services.AddScoped<Icrud<Link>, LinkRepository>();
builder.Services.AddScoped<IRecord<Record>, RecordRepository>();


// In Appsettings.Json lays the connectionstring to use EF
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
