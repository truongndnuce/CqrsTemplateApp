using Contract.Abtractions.Message;
using MediatR;

namespace CqrsApp.Application.Usecases.V1.Queries.Product;

public class GetProductQuery :  IQuery<GetProductResponse>
{
    public string Name { get; set; }
}