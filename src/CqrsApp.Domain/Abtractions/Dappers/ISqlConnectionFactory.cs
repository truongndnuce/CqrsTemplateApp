using System.Data;

namespace CqrsApp.Domain.Abtractions.Dappers;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
