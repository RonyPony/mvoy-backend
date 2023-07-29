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
builder.Services.AddDbContext<MvoyContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //opt.UseNpgsql(builder.Configuration.GetConnectionString("postgres"));

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddTransient<IVehicleService, VehicleService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITripService, TripService>();
builder.Services.AddTransient<ITripRepository, TripRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();

app.Run();
