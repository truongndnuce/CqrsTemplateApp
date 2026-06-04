using Contract.Abtractions.Message;
using CqrsApp.Domain.Shared ;
using MediatR ;
using static DemoCICD.Contract.Services.V1.Product.Response;

namespace Contract.Service.V1.Product;

public static class Query
{
    //public record GetProductsQuery(string? SearchTerm, string? SortColumn, SortOrder? SortOrder, IDictionary<string, SortOrder>? SortColumnAndOrder, int PageIndex, int PageSize) : IQuery<PagedResult<ProductResponse>>;
    public record GetProductByIdQuery(Guid Id) : IQuery<ProductResponse>;
    
    public record GetProductQuery(Guid Id) : IQuery<ProductResponse>, IQuery<List<ProductResponse>>, IRequest<Result<List<ProductResponse>>> ;

}
