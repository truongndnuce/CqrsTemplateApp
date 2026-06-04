using CqrsApp.Domain.Shared;
using MediatR;

namespace Contract.Abtractions.Message;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}