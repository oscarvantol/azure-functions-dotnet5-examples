using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Pipeline;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace ExampleFunction
{
    public class HttpFunction
    {
        [FunctionName(nameof(HttpFunction1))]
        public string HttpFunction1([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestData req, FunctionExecutionContext functionContext)
        {
            functionContext.Logger.LogInformation("You called the trigger with http {method}", req.Method);

            return "great";
        }
    }
}