using CqrsApp.Domain.Shared;
using MediatR;

namespace Contract.Abtractions.Message;

public interface ICommand : IRequest<Result>
{
    
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
    
}