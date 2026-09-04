using Contract.Abtractions.Message;
using Contract.Service.V1.Product;
using CqrsApp.Domain.Abtractions.Dappers;
using CqrsApp.Domain.Shared;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CqrsApp.Application.Usecases.V1.Queries.Product;

public sealed class GetProductDapperQueryHandler : IQueryHandler<Query.GetProductDapperQuery, List<Response.ProductResponse>>
{
    private readonly ISqlConnectionFactory _connectionFactory;
    private readonly ILogger<GetProductDapperQueryHandler> _logger;

    public GetProductDapperQueryHandler(ISqlConnectionFactory connectionFactory, ILogger<GetProductDapperQueryHandler> logger)
    {
        _connectionFactory = connectionFactory;
        _logger = logger;
    }

    public async Task<Result<List<Response.ProductResponse>>> Handle(Query.GetProductDapperQuery request, CancellationToken cancellationToken)
    {
        var timer = Stopwatch.StartNew();

        using var connection = _connectionFactory.CreateConnection();
        var products = await connection.QueryAsync<Response.ProductResponse>(
            "SELECT Id, Name, Price, Description FROM Product");

        timer.Stop();

        _logger.LogInformation("Request Details: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
            nameof(Query.GetProductDapperQuery), timer.ElapsedMilliseconds, request);

        return products.ToList();
    }
}
