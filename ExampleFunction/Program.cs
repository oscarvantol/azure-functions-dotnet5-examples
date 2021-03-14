using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ExampleFunction;

#if DEBUG
System.Diagnostics.Debugger.Launch();
#endif

var host = new HostBuilder()
    .ConfigureAppConfiguration(c =>
    {
        c.AddCommandLine(args);
        //c.AddEnvironmentVariables();
    })
    .ConfigureFunctionsWorkerDefaults((c, b) =>
    {
        b.UseExampleMiddleware();
        b.UseFunctionExecutionMiddleware();
    })
    .ConfigureServices(s =>
    {

    })
    .Build();

await host.RunAsync();