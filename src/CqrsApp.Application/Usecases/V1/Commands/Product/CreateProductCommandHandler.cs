using Contract.Abtractions.Message ;
using Contract.Service.V1.Product ;
using CqrsApp.Domain ;
using CqrsApp.Domain.Shared ;
using MediatR ;

namespace CqrsApp.Application.Usecases.V1.Commands.Product;

public sealed class CreateProductCommandHandler : ICommandHandler<Command.CreateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublisher _publisher;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IPublisher publisher)
    {
        _unitOfWork = unitOfWork;
        _publisher = publisher ;
    }

    public async Task<Result> Handle(Command.CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = CqrsApp.Domain.Entities.Product.CreateProduct(Guid.NewGuid(), request.Name, request.Price, request.Description);

        var result = await _unitOfWork.Products.AddAsync(product);

        await _publisher.Publish( new DomainEvent.ProductCreated( result.Id ), cancellationToken ) ;

        return Result.Success(result);
    }
}
