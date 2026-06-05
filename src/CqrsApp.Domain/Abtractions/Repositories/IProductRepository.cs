using CqrsApp.Domain.Entities;
using DemoCICD.Domain.Abstractions.Repositories;

namespace CqrsApp.Domain.Abtractions.Repositories;

public interface IProductRepository : IRepositoryBase<Product, Guid>
{
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default);
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);
    Task<Product> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
