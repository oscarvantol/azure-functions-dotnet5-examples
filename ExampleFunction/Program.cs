using ExampleFunction;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

#if DEBUG
//System.Diagnostics.Debugger.Launch();
#endif

var host = new HostBuilder()
    .ConfigureAppConfiguration(c =>
    {
        c.AddCommandLine(args);
        //c.AddEnvironmentVariables();
    })
    .ConfigureFunctionsWorkerDefaults(app =>
    {
        app.UseMiddleware<ExampleMiddleware>();
    })
    .ConfigureServices(s =>
    {

    })
    .Build();

await host.RunAsync();