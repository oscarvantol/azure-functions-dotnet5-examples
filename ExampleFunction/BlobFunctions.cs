using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ExampleFunction
{
    public class BlobFunctions
    { 
        [Function(nameof(BlobFunction1))]
        [BlobOutput("test-samples-output/{name}-output.txt")]
        public async Task<string> BlobFunction1(
         [BlobTrigger("test-samples-trigger/{name}")] string content,
         [BlobInput("test-samples-input/sample1.txt")] string inputContent,
         string name,
         FunctionContext context)
        {
            var logger = context.GetLogger("BlobFunction");
            logger.LogInformation($"Triggered Item Name = {name}");
            logger.LogInformation($"Triggered Item Content = {content}");
            logger.LogInformation($"Blobinput sample1  Content = {inputContent}");

            //This will be written in test-samples-output/{name}-output.txt"
            //name will be the used from the trigger blob's name
            return "Some output";
        }

        [Function(nameof(MediaUploadProcessorFunction))]
        public async Task MediaUploadProcessorFunction([BlobTrigger("media/{name}", Connection = "AzureWebJobsStorage")] byte[] myBlob, string name, FunctionContext context)
        {
            var logger = context.GetLogger("BlobExample");
            logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Content length: {myBlob?.Length}");
        }
    }
}