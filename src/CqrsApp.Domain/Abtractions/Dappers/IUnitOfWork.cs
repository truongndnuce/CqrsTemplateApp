using CqrsApp.Domain.Abtractions.Repositories;

namespace CqrsApp.Domain.Abtractions.Dappers;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
}
