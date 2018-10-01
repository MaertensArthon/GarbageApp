
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GarbageServices
{
    public static class Devide2Digits
    {
        [FunctionName("Devide2Digits")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "rekenmachine/delen/{digit1}/{digit2}")]HttpRequest req, int digit1, int digit2, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            int devider = digit1 / digit2;
 
            return devider != null
                ? (ActionResult)new OkObjectResult($"De deler bedraagt: {devider}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
