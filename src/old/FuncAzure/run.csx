#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

	public static float getNumber(int a, int b, Random _rnd)
	{
		return (float)_rnd.Next(a, b)+(float)((float)_rnd.Next(0,99)/100);
	}


public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# func to parse http and run select query");
    log.LogInformation("last edited: 20:44 21.10.2018");

//idMeas: auto
float _temp1,_press1 ;
		// Random rnd = new Random();
        // 		Console.WriteLine(" temp=    "+getNumber(15,25,rnd));
		// Console.WriteLine("press=    "+getNumber(980,1030,rnd));
    int _idSensor = 2; //cionst req.Query["temp1"];
if(float.TryParse(req.Query["temp1"], out _temp1)==false){_temp1 = 11.1;log.LogInformation("temp1 const 11.1");}
if(float.TryParse(req.Query["press1"], out _press1)==false){_press1 = 1111;log.LogInformation("press1 const 1111");}
    //date: now()



string query = $"INSERT INTO dbo.measurementsLogLatest11 (idSensor, dateMeas,valueMeas, sensorType)"+
$"VALUES ({_idSensor},GETDATE(),{_temp1}, 'temp1');"+
$"INSERT INTO dbo.measurementsLogLatest11 (idSensor, dateMeas,valueMeas, sensorType)"+
$"VALUES ({_idSensor},GETDATE(),{_press1}, 'press1');"

    log.LogInformation(query);

   // string _temp1 = req.Query["temp1"];
  //  string _press1 = req.Query["press1"];
    int _idSensor = 2; //cionst req.Query["temp1"];
  //  string _temp1 = req.Query["temp1"];





    return name != null
        ? (ActionResult)new OkObjectResult($"Hello, {name}")
        : new BadRequestObjectResult("Error, maybe bad parse");
}
