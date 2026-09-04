using AutoMapper;
using Contract.Abtractions.Message;
using Contract.Service.V1.Product ;
using CqrsApp.Domain.Shared;
using DemoCICD.Contract.Services.V1.Product;
using DemoCICD.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CqrsApp.Application.Usecases.V1.Queries.Product;

public sealed class GetProductQueryHandler : IQueryHandler<Query.GetProductQuery, List<Response.ProductResponse>>
{
    private readonly IRepositoryBase<Domain.Entities.Product,Guid>  _productRepository;
    private readonly IMapper  _mapper;

    public GetProductQueryHandler(IMapper mapper, IRepositoryBase<Domain.Entities.Product,Guid> productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
        
    public async Task<Result<List<Response.ProductResponse>>> Handle(Query.GetProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.FindAll().ToListAsync();
        var result = _mapper.Map<List<Response.ProductResponse>>( products ) ;
        return result ;
    }
}