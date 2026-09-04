using CqrsApp.Domain.Abtractions.Repositories;
using CqrsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsApp.Persistence.Repositories;

public class ProductRepository : RepositoryBase<Product, Guid>, IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context) : base(context)
        => _context = context;

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.Set<Product>().AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Set<Product>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

    public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Set<Product>().AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _context.Set<Product>().Update(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Set<Product>().FindAsync([id], cancellationToken)
            ?? throw new KeyNotFoundException($"Product {id} not found.");
        _context.Set<Product>().Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }
}
