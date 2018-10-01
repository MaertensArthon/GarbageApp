
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
    public static class TestParameters
    {
        [FunctionName("TestParameters")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "naam/{myname}")]HttpRequest req,string myname, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
              
            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return myname != null
                ? (ActionResult)new OkObjectResult($"Hello, {myname}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
