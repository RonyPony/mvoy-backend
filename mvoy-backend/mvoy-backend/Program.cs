using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mvoy.core.Contracts;
using mvoy.core.Interface;
using mvoy.data.DataContext;
using mvoy.data.Repository;
using mvoy.data.Services;
using mvoy_backend.Controllers;
using mvoy_backend.Web.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceCollection services;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<MvoyContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITripService, TripService>();
builder.Services.AddTransient<ITripRepository, TripRepository>();
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
