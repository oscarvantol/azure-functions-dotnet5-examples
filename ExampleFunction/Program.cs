using System.Diagnostics;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

#if DEBUG
Debugger.Launch();
#endif

var host = new HostBuilder()
    .ConfigureAppConfiguration(c => { c.AddCommandLine(args); })
    .ConfigureFunctionsWorker((c, b) => { b.UseFunctionExecutionMiddleware(); })
    .ConfigureServices(s => { })
    .Build();

await host.RunAsync();