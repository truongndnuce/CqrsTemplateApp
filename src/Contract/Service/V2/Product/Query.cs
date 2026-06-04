using Contract.Abtractions.Message;
using CqrsApp.Domain.Shared;
using static DemoCICD.Contract.Services.V2.Product.Response;

namespace Contract.Service.V2.Product;

public static class Query
{
    public record GetProductsQuery() : IQuery<Result<List<ProductResponse>>>;
    public record GetProductByIdQuery(Guid Id) : IQuery<ProductResponse>;
}
