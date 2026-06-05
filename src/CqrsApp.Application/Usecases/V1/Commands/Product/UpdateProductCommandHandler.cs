using Contract.Abtractions.Message ;
using Contract.Service.V1.Product ;
using CqrsApp.Domain ;
using CqrsApp.Domain.Exceptions ;
using CqrsApp.Domain.Shared ;

namespace CqrsApp.Application.Usecases.V1.Commands.Product;

public sealed class UpdateProductCommandHandler : ICommandHandler<Command.UpdateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(Command.UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id)
            ?? throw new ProductException.ProductNotFoundException(request.Id);

        product.Update(request.Name, request.Price, request.Description);

        var result = await _unitOfWork.Products.UpdateAsync(product);

        return Result.Success(result);
    }
}
