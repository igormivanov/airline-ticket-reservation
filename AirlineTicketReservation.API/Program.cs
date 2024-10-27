using AirlineTicketReservation.Data;
using Microsoft.EntityFrameworkCore;
using AirlineTicketReservation.API.Extensions;
using Microsoft.AspNetCore.Hosting;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using AirlineTicketReservation.API.Models.Dtos.Passenger;
using System.Text.Json.Serialization;
using AirlineTicketReservation.API.Middlewares;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
     });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:secret"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateAudience = false,
        ValidateIssuer = false

    };
});

// Data base
builder.Services.AddDbContext<AppDataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Fluent Validation ID
builder.Services.AddValidatorsFromAssemblyContaining<PassengerRequestDTOValidation>();


builder.Services.AddRepositoryServices();
builder.Services.AddUseCaseServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
