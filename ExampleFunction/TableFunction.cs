using System;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace ExampleFunction
{
    public class TableFunction
    {
        [Function(nameof(HttpToTableFunction))]
        public async Task<MyOutput> HttpToTableFunction([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "test-table-output")] HttpRequestData req)
        {
            var tableEntity = new MyTableData { PartitionKey = "test-table-output", RowKey = Guid.NewGuid().ToString(), Text = "some text" };

            var httpResponse = req.CreateResponse();
            await httpResponse.WriteStringAsync("Success");

            return new() { HttpResponse = httpResponse, MyTableData = tableEntity };
        }

        public class MyOutput
        {
            public HttpResponseData? HttpResponse { get; set; }

            [TableOutput("TestTable", Connection = "AzureWebJobsStorage")]
            public MyTableData? MyTableData { get; set; }
        }

        public class MyTableData
        {
            public string? PartitionKey { get; set; }

            public string? RowKey { get; set; }

            public string? Text { get; set; }
        }
    }
}