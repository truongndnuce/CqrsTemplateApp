using CqrsApp.Application.Behaviors ;
using FluentValidation ;
using MediatR ;
using Microsoft.Extensions.DependencyInjection ;

namespace CqrsApp.Application.DependencyInjection.Extentions ;

public static class ServiceCollectionExtentions
{
  public static IServiceCollection AddConfigureMediatR( this IServiceCollection services ) =>
    services.AddMediatR( cfg => cfg.RegisterServicesFromAssembly( AssemblyReferences.Assembly ) )
      .AddTransient( typeof( IPipelineBehavior<,> ), typeof( ValidationPipelineBehavior<,> ) )
      .AddValidatorsFromAssembly(Contract.AssemblyReferences.Assembly, includeInternalTypes: false);
}