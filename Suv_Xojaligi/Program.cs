using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Suv_Xojaligi.Data.Contexts;
using Suv_Xojaligi.Data.Entities;
using Suv_Xojaligi.V1.Auth.Services.Extentions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));



builder.Services.AddEntityFrameworkCore();
builder.Services.AddServiceConfiguration()
    .AddSwaggerService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
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
