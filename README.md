# azure-functions-dotnet5-examples
This is my personal playground for discovering the .NET 5 Azure functions worker preview.


If you are confused, you can read some background here:
- [Azure Functions in .NET 5 and beyond](https://dev.to/oscarvantol/azure-functions-in-net-5-and-beyond-26d6)


> **Everything here is based on**
> https://github.com/Azure/azure-functions-dotnet-worker-preview
> https://docs.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-process-guide

## Nice to know

~~### Why is there a TimerInfo record?
The timer function depends on the included TimerInfo class, for now it does not work with the normal Microsoft.Azure.WebJobs.TimerInfo
the TimerInfo class is implemented as a record to keep it clean ;)
If you are not reading from the timerinfo you can even just define it as an object.~~
TimerInfo is available in the latest version.


### Dependency injection in Startup?
If you were used to the Azure Functions Startup class, it is not here. It is actually now using a HostBuilder that you can find in Program.cs

### No ILogger method injection?
Nope, instead you can get ~~FunctionExecutionContext~~ FunctionContext which has the Logger and other goodies. Next to that you can inject ILogger<Thing> in the constructor of your functions class

### How to run:
- Install .NET 5.0
- Get core tools >= **3.0.3331**: https://github.com/Azure/azure-functions-core-tools
- Open the project in Visual Studio or VsCode.
- Open a terminal: 
``` 
cd ExampleFunction
func host start --verbose
The debugger will try to attach to your vs instance.
```


### Run a storage emulator
If you are used to running Azure Functions from Visual Studio you might not know that the tooling will spin up the AzureStorageEmulator for you if you run it. In the config file there is a setting ```"AzureWebJobsStorage": "UseDevelopmentStorage=true"``` and some triggers like TimerTrigger really need to store some state somewhere.

If you do not run the "Microsoft Azure Storage Emulator" or [Azurite](https://github.com/Azure/Azurite) you might encounter the following logs:
```
 An unhandled exception has occurred. Host is shutting down.
 Microsoft.Azure.Storage.Common: No connection could be made because the target machine actively refused it. System.Net.Http: No connection could be made because the target machine actively refused it. System.Private.CoreLib: No connection could be made because the target machine actively refused it.
 Stopping host...
 Stopping JobHost
```

**How to run Azurite**
```
# if you run docker:
docker run -p 10000:10000 -p 10001:10001 mcr.microsoft.com/azure-storage/azurite

# or install it from npm and run it
npm install -g azurite
mkdir c:\azurite
azurite -s -l c:\azurite -d c:\azurite\debug.log
```


### How to run in a devcontainer:

- Open vscode
- Install the `Remote - Container` extension
- Re-open the directory in a container `Remote - Containers: Open folder in Container`

Now you can execute the same commands as in How to run
