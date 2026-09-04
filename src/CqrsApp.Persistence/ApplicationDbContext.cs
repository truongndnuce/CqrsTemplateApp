using System.Reflection.Metadata ;
using CqrsApp.Domain.Entities ;
using CqrsApp.Domain.Entities.Identity ;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore ;
using Microsoft.EntityFrameworkCore ;
using Action = CqrsApp.Domain.Entities.Identity.Action;

namespace CqrsApp.Persistence;

public sealed class ApplicationDbContext( DbContextOptions<ApplicationDbContext> options )
    : IdentityDbContext<AppUser, AppRole, Guid>( options )
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(AssemblyReferences.Assembly);
    }

    public DbSet<AppUser> AppUses { get; set; }
    public DbSet<Action> Actions { get; set; }
    public DbSet<Function> Functions { get; set; }
    public DbSet<ActionInFunction> ActionInFunctions { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    public DbSet<Product> Products { get; set; }
}
