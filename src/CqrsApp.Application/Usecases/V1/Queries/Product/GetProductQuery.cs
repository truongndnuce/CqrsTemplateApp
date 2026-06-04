using Contract.Abtractions.Message;
using DemoCICD.Contract.Services.V1.Product;

namespace CqrsApp.Application.Usecases.V1.Queries.Product;

public class GetProductQuery : IQuery<List<Response.ProductResponse>>
{
    public string? Name { get; set; }
}
