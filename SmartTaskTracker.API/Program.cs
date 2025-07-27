using Microsoft.EntityFrameworkCore;
using SmartTaskTracker.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SmartTaskTracker.Application;
using SmartTaskTracker.Application.Users.Commands.CreateUser;
using SmartTaskTracker.Application.Users.DTOs;

var builder = WebApplication.CreateBuilder(args);

// 1) DbContext
builder.Services.AddDbContext<SmartTaskTrackerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2) MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(SomeApplicationMarker).Assembly)
);

builder.Services.AddControllers();

//builder.Services.AddScoped<IRequestHandler<CreateUserCommand, UserDto>, CreateUserCommandHandler>();

// 3) Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
