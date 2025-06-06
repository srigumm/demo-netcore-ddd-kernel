
namespace ZXYZ.GraphQL.Queries;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class AttendeeMutations
{
   public string SayHello(string name) => $"Hello, {name}!";
}