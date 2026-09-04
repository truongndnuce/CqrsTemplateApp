using CqrsApp.Domain;
using CqrsApp.Domain.Abtractions.Repositories;
using CqrsApp.Persistence.Repositories;

namespace CqrsApp.Persistence;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IProductRepository Products { get; }

    public EFUnitOfWork(ApplicationDbContext context, IProductRepository products)
    {
        _context = context;
        Products = products;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);

    async ValueTask IAsyncDisposable.DisposeAsync()
        => await _context.DisposeAsync();
}