using CqrsApp.Persistence.DependencyInjection.Options ;
using Microsoft.EntityFrameworkCore ;
using Microsoft.Extensions.Configuration ;
using Microsoft.Extensions.DependencyInjection ;
using Microsoft.Extensions.Options ;

namespace CqrsApp.Persistence.DependencyInjection.Extentions ;

public static class ServiceCollectionExtentions
{
  public static void AddSqlConfiguration( this IServiceCollection services )
  {
    services.AddDbContextPool<DbContext, ApplicationDbContext>((provider, builder) =>
    {
      var configuration = provider.GetRequiredService<IConfiguration>();
      var options = provider.GetRequiredService<IOptionsMonitor<SqlServerRetryOptions>>();

      builder
        .EnableDetailedErrors(true)
        .EnableSensitiveDataLogging(true)
        .UseLazyLoadingProxies(true) // => If UseLazyLoadingProxies, all of the navigation fields should be VIRTUA
        .UseSqlServer(
          connectionString: configuration.GetConnectionString("ConnectionStrings"),
          sqlServerOptionsAction: optionsBuilder
            => optionsBuilder.ExecutionStrategy(
                dependencies => new SqlServerRetryingExecutionStrategy(
                  dependencies: dependencies,
                  maxRetryCount: options.CurrentValue.MaxRetryCount,
                  maxRetryDelay: options.CurrentValue.MaxRetryDelay,
                  errorNumbersToAdd: options.CurrentValue.ErrorNumbersToAdd))
              .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));
    });
  }

   public static OptionsBuilder<SqlServerRetryOptions> ConfigureSqlServerRetryOptions( this IServiceCollection services,
      IConfigurationSection section ) =>
      services.AddOptions<SqlServerRetryOptions>().Bind( section ).ValidateOnStart() ;
}