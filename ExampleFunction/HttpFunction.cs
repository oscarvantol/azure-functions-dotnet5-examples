using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ExampleFunction
{
    public class HttpFunction
    {
        [Function(nameof(HttpFunction1))]
        public async Task<string> HttpFunction1([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "test")] HttpRequestData req, FunctionContext functionContext)
        {
            var log = functionContext.GetLogger<HttpFunction>();
            log.LogInformation("You called the trigger!");

            return "Hello world";
        }

        [Function(nameof(HttpFunction2))]
        public string HttpFunction2([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "testerror")] HttpRequestData req, FunctionContext functionContext)
        {
            //Just an example to catch the exception in middleware
            throw new System.NotImplementedException("catch in middleware");
        }
    }
}