
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
    public static class Count2Digits
    {
        [FunctionName("Count2Digits")]
        public static async Task<IActionResult> Som([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "rekenmachine/som/{digit1}/{digit2}")]HttpRequest req, int digit1, int digit2, ILogger log)
        {
            log.LogInformation("Som function actief");
            int som = digit1 + digit2;
            return new OkObjectResult(som);
        }
    }
}
