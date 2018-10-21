#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# func to parse http and run select query");
    log.LogInformation("last edited: 20:44 21.10.2018");

//idMeas: auto
float _temp1,_press1 ;

    int _idSensor = 2; //cionst req.Query["temp1"];
if(float.TryParse(req.Query["temp1"], out _temp1)==false)_temp1 = 11.1;
if(float.TryParse(req.Query["press1"], out _press1)==false)_press1 = 1111;
    //date: now()



string query = $"INSERT INTO dbo.measurementsLogLatest11 (idSensor, dateMeas,valueMeas, sensorType)"+
$"VALUES ({_idSensor},GETDATE(),ROUND(RAND()*(25-10+1)+10,2), 'temp1');";

    log.LogInformation(query);

   // string _temp1 = req.Query["temp1"];
  //  string _press1 = req.Query["press1"];
    int _idSensor = 2; //cionst req.Query["temp1"];
  //  string _temp1 = req.Query["temp1"];





    return name != null
        ? (ActionResult)new OkObjectResult($"Hello, {name}")
        : new BadRequestObjectResult("Error, maybe bad parse");
}
