using EmpireHomes_BE;
using EmpireHomes_BE.Extensions;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dev"));
});


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowedOrigins",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});

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


app.ConfigureExceptionHandler(app.Logger);

app.UseHttpsRedirection();

app.UseCors("AllowedOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
