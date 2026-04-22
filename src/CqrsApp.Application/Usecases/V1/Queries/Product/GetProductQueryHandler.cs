using MediatR;

namespace CqrsApp.Application.Usecases.V1.Queries.Product;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery , GetProductResponse>
{
    public Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}