using MediatR;

namespace CqrsApp.Application.Usecases.V1.Queries.Product;

public class GetProductQuery :  IRequest, IRequest<GetProductResponse>
{
    
}