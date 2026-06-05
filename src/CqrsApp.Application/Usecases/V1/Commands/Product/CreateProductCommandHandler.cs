using Contract.Abtractions.Message ;
using Contract.Service.V1.Product ;
using CqrsApp.Domain ;
using CqrsApp.Domain.Shared ;

namespace CqrsApp.Application.Usecases.V1.Commands.Product;

public sealed class CreateProductCommandHandler : ICommandHandler<Command.CreateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(Command.CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = CqrsApp.Domain.Entities.Product.CreateProduct(Guid.NewGuid(), request.Name, request.Price, request.Description);

        var result = await _unitOfWork.Products.AddAsync(product);

        return Result.Success(result);
    }
}
