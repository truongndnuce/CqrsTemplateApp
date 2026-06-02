using Contract.Abtractions.Message;
using CqrsApp.Domain.Shared;
using MediatR;

namespace CqrsApp.Application.Usecases.V1.Commands.Product;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    public Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}