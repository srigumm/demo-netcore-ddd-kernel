namespace ZXYZ.SharedCore.Middleware.Extensions;

using HotChocolate.Execution.Configuration;
using HotChocolate.Types.Descriptors;
using HotChocolate.Utilities;
public static class RequestExecutorBuilderExtensions
{

    public static IRequestExecutorBuilder AddSnakeCaseNamingConvention(this IRequestExecutorBuilder builder)
    {
        //builder.AddConvention<INamingConventions, SnakeCaseNamingConvention>();
        return builder;
    }

}
