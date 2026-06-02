using Contract.Abtractions.Message;

namespace CqrsApp.Application.Usecases.V1.Queries.Product;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery , GetProductResponse>
{
    public Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}