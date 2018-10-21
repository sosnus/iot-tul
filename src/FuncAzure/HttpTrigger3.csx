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
    log.LogInformation(">>>>> C# func to parse http and run select query");
    log.LogInformation(">>>>> last edited: 20:44 21.10.2018");

		Random rnd = new Random();
//idMeas: auto
float _temp1,_press1 ;

    int _idSensor = 2; //cionst req.Query["temp1"];
if(float.TryParse(req.Query["temp1"], out _temp1)==false){
    _temp1 = (float)-2;
    log.LogInformation("temp1 const 11.1");
    }
else if(_temp1 == -1){
    _temp1 = getNumber(15,25,rnd);
    log.LogInformation($"temp1 rand {_temp1}");
    }
if(float.TryParse(req.Query["press1"], out _press1)==false){
    _press1 = (float)-2;
    log.LogInformation("press1 const 1111");
    }
else if(_press1 == -1){
    _press1 = getNumber(980,1030,rnd);
    log.LogInformation($"temp1 rand {_press1}");
    }
    //date: now()
string name = "aaa";
    return _temp1 != -2
        ? (ActionResult)new OkObjectResult($"Hello, {name}, Temp={_temp1}, Press={_press1}")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
}
