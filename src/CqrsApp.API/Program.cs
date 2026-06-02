using CqrsApp.Application.Behaviors;
using FluentValidation;
using MediatR;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddMediatR(opts => opts.RegisterServicesFromAssembly(CqrsApp.Application.AssemblyReferences.Assembly));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
builder.Services.AddValidatorsFromAssembly(CqrsApp.Application.AssemblyReferences.Assembly, includeInternalTypes: true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(endpointPrefix: "/swagger");
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
