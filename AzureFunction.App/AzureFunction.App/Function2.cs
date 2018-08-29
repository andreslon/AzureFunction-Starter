using AzureFunction.Infrastructure.Repositories.Interfaces;
using DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;

namespace AzureFunction.App
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, ILogger log, [Inject]IMyRepository myRepository)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;


            var AzureWebJobsStorage = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

            return name != null
                ? (ActionResult)new OkObjectResult($"{myRepository.Greet()}, {name} + AzureWebJobsStorage: { AzureWebJobsStorage}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
