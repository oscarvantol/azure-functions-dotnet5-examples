using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ExampleFunction
{
    public class WarmupFunction
    {
        [Function(nameof(Warmup))]
        public void Warmup([WarmupTrigger()] object warmupContext, FunctionContext functionContext)
        {
            //warmup is only supported in premium plan
        }

    }
}
