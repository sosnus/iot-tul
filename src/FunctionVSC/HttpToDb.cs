using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class HttpToDb
    {
        [FunctionName("HttpToDb")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            log.LogInformation("Query string:" + req.QueryString);
            log.LogInformation("Params count:" + req.Query.Count);
            int i = 0;
            string __temp = "A";
            foreach (string key in req.Query.Keys)
            {
                if(i>0)
                {
                __temp += i + ":" + key + "=" + req.Query[key] + "\n";
                log.LogInformation(__temp);
                }
                i++;
            }

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello2222, {__temp}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
``