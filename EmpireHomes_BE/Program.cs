using Azure.Extensions.AspNetCore.Configuration.Secrets;
using EmpireHomes_BE;
using EmpireHomes_BE.Controllers.Services.Azure;
using EmpireHomes_BE.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBlobStorage, BlobStorage>();

KeyVault keyVault = new(builder.Configuration);
var client = keyVault.GetKeyVaultClient();
builder.Configuration.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["SQLConnectionString"], options => options.EnableRetryOnFailure());
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowedOrigins",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000", 
                                    "https://empire-homes.azurewebsites.net",
                                    "https://empire-homes-uat.azurewebsites.net")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});



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
