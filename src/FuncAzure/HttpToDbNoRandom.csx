#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;

using System.Data.SqlClient;
using System.Configuration;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
int status = 0;
    log.LogInformation("[START..........................]");
    string json = await new StreamReader(req.Body).ReadToEndAsync();
    log.LogInformation($" [HTTP BODY]: {json}");
    Measure myMeasure = new Measure(json);
    for (int i = 0; i < myMeasure.sensorType.Length; i++)
    {
        double temp = -2;
        if (double.TryParse(myMeasure.valueMeas.GetValue(i).ToString(), out temp) == true)
        {
            string temp_query = $"INSERT INTO dbo.measurementsLogLatest22(idSensor, dateMeas, sensorType, valueMeas) " +
                    $"VALUES({myMeasure.idSensor},'{myMeasure.dateMeas}','{myMeasure.sensorType.GetValue(i).ToString()}',{temp.ToString()});";
            log.LogInformation($" [EXECUTE QUERY]: {temp_query}");
            string str2 = "Server=tcp:iot-tul-dashboard-db.database.windows.net,1433;Initial Catalog=iot-tul-dashboard-db;Persist Security Info=False;User ID=tul-admin;Password=22DQqNdU;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection conn = new SqlConnection(str2))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(temp_query, conn))
                {
                    var rows = await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        else
        {
            status++;
            log.LogWarning($"[BAD CONVERT]: can't convert value: {myMeasure.valueMeas.GetValue(i).ToString()} from sensorType: {myMeasure.sensorType.GetValue(i).ToString()}");
        }
    }

    log.LogInformation("[STOP..........................]");
    if(status == 0) return new OkObjectResult($"ALL DATA WRITTEN OK");
    else return new BadRequestObjectResult($"ERROR CNT={status}");
    // return 1 != null
    //     ? (ActionResult)new OkObjectResult($"Hello, name")
        // : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
}

public class Measure
{
    public Measure(string json)
    {
        JObject jObject = JObject.Parse(json);
        JToken jMeasure = jObject["measure"];
        idSensor = (string)jMeasure["idSensor"];
        sensorType = jMeasure["sensorType"].ToArray();
        valueMeas = jMeasure["valueMeas"].ToArray();
        DateTime myDateTime = DateTime.Now;
        dateMeas = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"); // date is prepare when Json is parsed; date is string, not DateTime
    }
    public string idSensor { get; set; }
    public string dateMeas { get; set; }
    public Array sensorType { get; set; }
    public Array valueMeas { get; set; }
}
