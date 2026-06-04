using AutoMapper;
using Contract.Abtractions.Message;
using CqrsApp.Domain.Shared;
using DemoCICD.Contract.Services.V1.Product;
using DemoCICD.Domain.Abstractions.Repositories;

namespace CqrsApp.Application.Usecases.V1.Queries.Product;

public sealed class GetProductQueryHandler : IQueryHandler<GetProductQuery , List<Response.ProductResponse>>
{
    private readonly IRepositoryBase<Domain.Entities.Product,Guid>  _productRepository;
    private readonly IMapper  _mapper;

    public GetProductQueryHandler(IMapper mapper, IRepositoryBase<Domain.Entities.Product,Guid> productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
        
    public async Task<List<Response.ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        //var products = await _productRepository.FindAll();
        //return new Task<List<Response.ProductResponse>>(result);
        return null;
    }
}