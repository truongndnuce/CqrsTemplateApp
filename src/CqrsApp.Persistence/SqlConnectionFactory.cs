using System.Data;
using CqrsApp.Domain.Abtractions.Dappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CqrsApp.Persistence;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ConnectionStrings")!;
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
