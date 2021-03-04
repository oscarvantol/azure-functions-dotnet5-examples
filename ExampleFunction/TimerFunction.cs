using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ExampleFunction
{
    public class TimerFunction
    {
        [Function(nameof(TimerFunction1))]
        public void TimerFunction1([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo myTimer, FunctionContext functionContext)
        {
            var log = functionContext.GetLogger<HttpFunction>();
            log.LogWarning("timer was triggered! scheduleStatus: {scheduleStatus}", myTimer.ScheduleStatus);
        }
    }
}
