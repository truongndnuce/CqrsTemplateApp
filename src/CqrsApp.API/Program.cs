using CqrsApp.Application.Behaviors;
using CqrsApp.Application.DependencyInjection.Extentions ;
using CqrsApp.Persistence.DependencyInjection.Extentions ;
using CqrsApp.Persistence.DependencyInjection.Options ;
using FluentValidation;
using MediatR;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddConfigureMediatR() ;
builder.Services.ConfigureSqlServerRetryOptions(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(endpointPrefix: "/swagger");
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
