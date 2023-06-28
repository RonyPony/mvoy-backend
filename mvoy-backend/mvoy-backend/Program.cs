using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mvoy.data.DataContext;
using mvoy_backend.Web.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceCollection services;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
//builder.Services.AddDbContext<MvoyContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]));
// configure strongly typed settings objects  
//var appSettingsSection = Configuration.GetSection("ServiceConfiguration");
//builder.Services.Configure<ServiceConfiguration>(appSettingsSection);
//builder.Services.AddTransient<Services.IIdentityService, Services.IdentityService>();
// configure jwt authentication  
//var serviceConfiguration = appSettingsSection.Get<ServiceConfiguration>();
//var JwtSecretkey = Encoding.ASCII.GetBytes(serviceConfiguration.JwtSettings.Secret);
//var tokenValidationParameters = new TokenValidationParameters
//{
//    ValidateIssuerSigningKey = true,
//    IssuerSigningKey = new SymmetricSecurityKey(JwtSecretkey),
//    ValidateIssuer = false,
//    ValidateAudience = false,
//    RequireExpirationTime = false,
//    ValidateLifetime = true
//};
//builder.Services.AddSingleton(tokenValidationParameters);
//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

//})
//            .AddJwtBearer(x =>
//            {
//                x.RequireHttpsMetadata = false;
//                x.SaveToken = true;
//                x.TokenValidationParameters = tokenValidationParameters;

//            });
//builder.Services.AddCors(
//    options =>
//    {
//        options.AddPolicy("CorsPolicy", builder =>
//        builder.AllowAnyOrigin()
//     .AllowAnyMethod()
//     .AllowAnyHeader()
//     );
//    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   
}
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.MapControllers();

app.Run();
