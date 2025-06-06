namespace ZXYZ.GraphQL.Queries;
using HotChocolate.Authorization;
[ExtendObjectType(OperationTypeNames.Query)]
public class HealthCheckQuery
{
    [Authorize]
    public string Ping()
    {
        return "Pong12";
    }
}