using CqrsApp.Application.Behaviors ;
using CqrsApp.Application.Mapper;
using CqrsApp.Persistence;
using DemoCICD.Domain.Abstractions;
using FluentValidation ;
using MediatR ;
using Microsoft.Extensions.DependencyInjection ;

namespace CqrsApp.Application.DependencyInjection.Extentions ;

public static class ServiceCollectionExtentions
{
  public static IServiceCollection AddConfigureMediatR( this IServiceCollection services ) =>
    services.AddMediatR( cfg => cfg.RegisterServicesFromAssembly( AssemblyReferences.Assembly ) )
      .AddTransient( typeof( IPipelineBehavior<,> ), typeof( ValidationPipelineBehavior<,> ) )
      .AddTransient( typeof( IPipelineBehavior<,> ), typeof( TransactionPipelineBehavior<,> ) )
      .AddValidatorsFromAssembly(Contract.AssemblyReferences.Assembly, includeInternalTypes: false);

  public static IServiceCollection AddConfigurationAutoMapper(this IServiceCollection services)
      => services.AddAutoMapper(cfg => cfg.AddProfile<ServiceProfile>());


}