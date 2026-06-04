using CqrsApp.Domain.Shared ;
using MediatR;

namespace Contract.Abtractions.Message;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
  where TQuery : IQuery<TResponse>, IRequest<Result<TResponse>>
{
    
}