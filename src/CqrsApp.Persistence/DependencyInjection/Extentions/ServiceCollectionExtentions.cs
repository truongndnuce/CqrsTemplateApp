using CqrsApp.Domain;
using CqrsApp.Domain.Abtractions.Repositories;
using CqrsApp.Domain.Entities.Identity;
using CqrsApp.Persistence.DependencyInjection.Options;
using CqrsApp.Persistence.Repositories;
using DemoCICD.Domain.Abstractions;
using DemoCICD.Domain.Abstractions.Repositories;
using Microsoft.AspNetCore.Identity ;
using Microsoft.EntityFrameworkCore ;
using Microsoft.Extensions.Configuration ;
using Microsoft.Extensions.DependencyInjection ;
using Microsoft.Extensions.Options ;

namespace CqrsApp.Persistence.DependencyInjection.Extentions ;

public static class ServiceCollectionExtentions
{
  public static void AddSqlConfiguration( this IServiceCollection services )
  {
    services.AddDbContextPool<ApplicationDbContext>((provider, builder) =>
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
    
    services.AddIdentityCore<AppUser>()
      .AddRoles<AppRole>()
      .AddEntityFrameworkStores<ApplicationDbContext>();

    services.Configure<IdentityOptions>(options =>
    {
      options.Lockout.AllowedForNewUsers = true; // Default true
      options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2); // Default 5
      options.Lockout.MaxFailedAccessAttempts = 3; // Default 5

      options.Password.RequireDigit = false;
      options.Password.RequireLowercase = false;
      options.Password.RequireNonAlphanumeric = false;
      options.Password.RequireUppercase = false;
      options.Password.RequiredLength = 6;
      options.Password.RequiredUniqueChars = 1;
    });
  }

   public static OptionsBuilder<SqlServerRetryOptions> ConfigureSqlServerRetryOptions( this IServiceCollection services,
      IConfigurationSection section ) =>
      services.AddOptions<SqlServerRetryOptions>().Bind( section ).ValidateOnStart() ;
   
   public static void AddRepositoryBaseConfiguration(this IServiceCollection services)
   {
     services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
     services.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
     services.AddTransient<IProductRepository, ProductRepository>();
   }
}