using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ExampleFunction;

#if DEBUG
//System.Diagnostics.Debugger.Launch();
#endif

var host = new HostBuilder()
    .ConfigureAppConfiguration(c =>
    {
        c.AddCommandLine(args);
        //c.AddEnvironmentVariables();
    })
    .ConfigureFunctionsWorker((c, b) =>
    {
        b.UseFunctionExecutionMiddleware();
        //b.UseExampleMiddleware();
    })
    .ConfigureServices(s =>
    {

    })
    .Build();

await host.RunAsync();