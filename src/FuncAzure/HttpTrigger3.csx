#r "Newtonsoft.Json"
#r "System.Configuration"
#r "System.Data"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

using System.Data.SqlClient;
using System.Configuration;


public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation(">>>>> C# func to parse http and run select query");
    log.LogInformation(">>>>> last edited: 00:06 22.10.2018");

		Random rnd = new Random();
        //prepare
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
//string name = "aaa";

//sql
//  /*
      //  var str = ConfigurationManager.ConnectionStrings["sqldb_connection"].ConnectionString;
        string str2 = "Server=tcp:iot-tul-dashboard-db.database.windows.net,1433;Initial Catalog=iot-tul-dashboard-db;Persist Security Info=False;User ID=tul-admin;Password=22DQqNdU;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        log.LogInformation($"STR >>{str2} <<");
    using (SqlConnection conn = new SqlConnection(str2))
    {
        conn.Open();
        var text3 = "INSERT INTO dbo.measurementsLogLatest11 (idSensor, dateMeas,valueMeas, sensorType)VALUES (2,GETDATE(),ROUND(RAND()*(25-10+1)+10,2), 'temp1');";
        var text = "INSERT INTO dbo.measurementsLogLatest11  (idSensor, dateMeas,valueMeas, sensorType)"+
        "VALUES (2,GETDATE(),ROUND(RAND()*(25-10+1)+10,2), 'temp1');"+
"INSERT INTO dbo.measurementsLogLatest11 (idSensor, dateMeas,valueMeas, sensorType)"+
"VALUES (2,GETDATE(),980+ROUND(RAND()*(25-10+1)+10,2), 'pressure1');";
// "SELECT * FROM measurementsLogLatest11;"; 
        using (SqlCommand cmd = new SqlCommand(text, conn))
        {
            // Execute the command and log the # rows affected.
            var rows = await cmd.ExecuteNonQueryAsync();
            log.LogInformation($"{rows} rows were updated");
        }
    }
//      */

    return _temp1 != -2
        ? (ActionResult)new OkObjectResult($"Hello, Temp={_temp1}, Press={_press1}")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
}


	public static float getNumber(int a, int b, Random _rnd)
	{
		return (float)_rnd.Next(a, b)+(float)((float)_rnd.Next(0,99)/100);
	}


// https://iot-tul-function.azurewebsites.net/api/HttpTrigger3?code=a6UqER8tFZ8fMXILqe2ksQHI7efFqKReYjVK4cQcxNCToRZI35xFpg==&temp1=-1&press1=-1

