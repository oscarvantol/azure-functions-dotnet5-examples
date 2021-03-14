using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;

namespace ExampleFunction
{
    public class ExampleMiddleware : IFunctionsWorkerMiddleware
    {
        public Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var log = context.GetLogger(nameof(ExampleMiddleware));
            log.LogWarning("We are watching you from middleware!");
            log.LogWarning("You have executed {functionName}", context.FunctionDefinition.Name);

            if (context.BindingContext.BindingData.TryGetValue("Headers", out var value) && value is string headers)
            {
                log.LogInformation("Your headers are: {headers}", headers);
            }

            return next(context);
        }
    }
}
