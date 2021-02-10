# azure-functions-dotnet5-examples

Everything here is based on https://github.com/Azure/azure-functions-dotnet-worker-preview



### How to run:

- Install .NET 5.0
- Get core tools >= 3.0.3160: https://github.com/Azure/azure-functions-core-tools
- Open the project in Visual Studio.
- Open a terminal: 
``` 
cd ExampleFunction
func host start --verbose
The debugger will try to attach to your vs instance.
```

### How to run in a devcontainer:

- Open vscode
- Install the `Remote - Container` extension
- Re-open the directory in a container `Remote - Containers: Open folder in Container`

Now you can execute the same commands as in How to run
