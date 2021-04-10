using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ExampleFunction
{
    public class DiLoggerHttpFunction
    {
        private ILogger<DiLoggerHttpFunction> _logger;

        public DiLoggerHttpFunction(ILogger<DiLoggerHttpFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(HttpFunction3))]
        public async Task<string> HttpFunction3([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "loggertest")] HttpRequestData req)
        {
            _logger.LogInformation("Logging with logger that is injected in the constructor");

            return "Hello world";
        }
    }
}