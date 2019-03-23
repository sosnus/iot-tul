#r "Newtonsoft.Json"

using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("New message from TTN");

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);

    string value = data?.payload_fields.Value;
    string sensorID = data?.payload_fields.sensorID;
    string sensorPassword = data?.payload_fields.sensorPassword;
    string result11 = "aa";
    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://lorastore20181206101456.azurewebsites.net/api/Measurements");
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";

    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
        string json = "{ 'SensorId': " + sensorID + ", 'Value': " + value + ", 'SensorPassword': '" + sensorPassword + "'}";
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        log.LogInformation("result back");
        result11 = result;
    }

    return value != null
        ? (ActionResult)new OkObjectResult($"Write to application: value={value} sensorID={sensorID} pass=")
        : new BadRequestObjectResult("Function error");
}
