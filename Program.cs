using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProcessRUsAssessment.AutoMapperConfig;
using ProcessRUsAssessment.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProcessRUsAssessmentDBContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ProcessRUsAssessmentDBConnectionString")));

builder.Services.AddIdentityCore<User>().AddRoles<Role>().AddEntityFrameworkStores<ProcessRUsAssessmentDBContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

//Error Log
builder.Host.UseSerilog((context, loggerConfiguration) => {
    loggerConfiguration.WriteTo.Console().ReadFrom.Configuration(context.Configuration);
});

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(MapperConfig));

//JWT Injecion
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
