using AzureFunction.Infrastructure.Repositories.Interfaces;
using DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace AzureFunction.App
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log, [Inject]IMyRepository myRepository)
        {
            var customSetting = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}  {myRepository.Greet()}");
        }
    }
}
