using CqrsApp.Domain.Abtractions.Repositories;

namespace CqrsApp.Domain;

public interface IUnitOfWork : IAsyncDisposable
{
    IProductRepository Products { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
