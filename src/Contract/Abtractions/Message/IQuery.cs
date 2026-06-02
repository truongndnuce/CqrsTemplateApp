using MediatR;

namespace Contract.Abtractions.Message;

public interface IQuery<TResponse> : IRequest<TResponse>
{
    
}