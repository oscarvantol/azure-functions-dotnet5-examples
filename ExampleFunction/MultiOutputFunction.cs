using System;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace ExampleFunction
{
    /// <summary>
    /// Example using some c#9 magic
    /// Created a positional record with output bindings
    /// Use targeted type new for returnvalue
    /// </summary>
    public class MultiOutputFunction
    {
        public record MultiOutputResult(HttpResponseData Response, [property: BlobOutput("multioutput/example.txt")] string BlobContent);

        [Function(nameof(MultiOutput))]
        public async Task<MultiOutputResult> MultiOutput([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "MultiOutput")] HttpRequestData req)
        {
            var response = req.CreateResponse();
            response.WriteString("Hello world");

            return new(response, DateTime.UtcNow.ToString());
        }
    }
}