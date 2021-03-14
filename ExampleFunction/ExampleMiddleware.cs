using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ExampleFunction
{
    public class ExampleMiddleware
    {
        public Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var log = context.GetLogger("middleware");
            log.LogWarning("We are watching you from middleware!");

            return next(context);
        }
    }

    public static class ApplicationBuilderExtensions
    {
        public static IFunctionsWorkerApplicationBuilder UseExampleMiddleware(this IFunctionsWorkerApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ExampleMiddleware>();
            return builder.Use((next) => (context) =>
                {
                    var middleware = context.InstanceServices.GetRequiredService<ExampleMiddleware>();
                    return middleware.Invoke(context, next);
                }
            );
        }
    }
}
