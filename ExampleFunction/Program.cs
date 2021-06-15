using ExampleFunction;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


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
        s.AddOptions<ExampleConfig>().Configure<IConfiguration>((s, c) => c.GetSection("ExampleConfig").Bind(s));
    })
    .Build();

await host.RunAsync();