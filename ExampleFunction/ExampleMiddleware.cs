using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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
            builder.Use(next =>
            {
                return context =>
                {
                    var middleware = context.InstanceServices.GetRequiredService<ExampleMiddleware>();

                    return middleware.Invoke(context, next);
                };
            });

            return builder;
        }
    }
}
