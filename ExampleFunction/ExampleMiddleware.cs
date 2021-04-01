using System;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware; 
using Microsoft.Extensions.Logging;

namespace ExampleFunction
{
    public class ExampleMiddleware : IFunctionsWorkerMiddleware
    {
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var log = context.GetLogger(nameof(ExampleMiddleware));
            log.LogWarning("We are watching you from middleware!");
            log.LogWarning("You have requested {functionName}", context.FunctionDefinition.Name);

            if (context.BindingContext.BindingData.TryGetValue("Headers", out var value) && value is string headers)
            {
                log.LogInformation("Your headers are: {headers}", headers);
            }

            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                log.LogWarning($"Something happened: {e.Message}");

            }
            finally
            {
                log.LogInformation("end of middleware");
            }
        }
    }
}
