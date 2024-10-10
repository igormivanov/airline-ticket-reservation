using AirlineTicketReservation.Data;
using Microsoft.EntityFrameworkCore;
using AirlineTicketReservation.API.Extensions;
using Microsoft.AspNetCore.Hosting;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using AirlineTicketReservation.API.Dtos.Passenger;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<>)
builder.Services.AddValidatorsFromAssemblyContaining<PassengerRequestDTOValidation>();


builder.Services.AddRepositoryServices();
builder.Services.AddUseCaseServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
