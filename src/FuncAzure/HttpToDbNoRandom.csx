#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;


public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{

            Random rnd = new Random();
string json = await new StreamReader(req.Body).ReadToEndAsync();

 log.LogInformation(json);
 Measure myMeasure = new Measure(json);
            for (int i = 0; i < myMeasure.sensorType.Length; i++)
            {
                string tempString = myMeasure.valueMeas.GetValue(i).ToString().Replace('.', ',');
                double temp = -2;
                if (double.TryParse(tempString, out temp) == true)
                {
                    string temp_query = $"INSERT INTO dbo.measurementsLog(idSensor, dateMeas, sensorType, valueMeas) " +
                            $"VALUES({myMeasure.idSensor},{myMeasure.dateMeas},{myMeasure.sensorType.GetValue(i).ToString()},{temp.ToString().Replace(',', '.')});";
                    log.LogInformation(temp_query);
                }
                else
                { 
                     log.LogInformation($"ERROR: can't convert value: {tempString} from sensorType: {myMeasure.sensorType.GetValue(i).ToString()}");
                }
            }

    return 1 != null
        ? (ActionResult)new OkObjectResult($"Hello, name")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
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
