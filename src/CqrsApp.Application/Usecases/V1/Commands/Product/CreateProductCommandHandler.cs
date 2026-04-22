using MediatR;

namespace CqrsApp.Application.Usecases.V1.Commands.Product;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}