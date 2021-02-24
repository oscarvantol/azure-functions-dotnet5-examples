using System;
using Microsoft.Azure.Functions.Worker.Pipeline;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ExampleFunction
{
    public class TimerFunction
    {
        [FunctionName(nameof(TimerFunction1))]
        public void TimerFunction1([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo myTimer, FunctionExecutionContext functionContext)
        {
            functionContext.Logger.LogWarning("timer was triggered! scheduleStatus: {scheduleStatus}", myTimer.ScheduleStatus);
        }
    }
}
