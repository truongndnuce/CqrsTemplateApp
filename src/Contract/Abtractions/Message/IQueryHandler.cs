using MediatR;

namespace Contract.Abtractions.Message;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
  where TQuery : IQuery<TResponse>
{
    
}