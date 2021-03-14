using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ExampleFunction
{
    public class HttpFunction
    {
        [Function(nameof(HttpFunction1))]
        public string HttpFunction1([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "test")] HttpRequestData req, FunctionContext functionContext)
        {
            var log = functionContext.GetLogger<HttpFunction>();            
            log.LogInformation("You called the trigger with http {method}", req.Method);

            return "great";
        }
    }
}