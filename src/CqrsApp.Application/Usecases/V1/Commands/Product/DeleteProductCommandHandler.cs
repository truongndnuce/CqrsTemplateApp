using Contract.Abtractions.Message ;
using Contract.Service.V1.Product ;
using CqrsApp.Domain ;
using CqrsApp.Domain.Exceptions ;
using CqrsApp.Domain.Shared ;

namespace CqrsApp.Application.Usecases.V1.Commands.Product;

public sealed class DeleteProductCommandHandler : ICommandHandler<Command.DeleteProductCommand>
{
    private readonly IUnitOfWork _unitOfWork; // SQL-SERVER-STRATEGY-2

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(Command.DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id)
            ?? throw new ProductException.ProductNotFoundException(request.Id);

        var result = await _unitOfWork.Products.DeleteAsync(product.Id);

        return Result.Success(result);
    }
}
