using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{""measure"":{""idSensor"":""1"",""sensorType"":[""temp1"",""press1"",""hum""],""valueMeas"":[""-2"",""-2"",""-2""]}}";
            Measure myMeasure = new Measure(json);
            Console.WriteLine("idSensor : " + myMeasure.idSensor);
            Console.WriteLine("Data:");
            for (int i = 0; i < myMeasure.sensorType.Length; i++)
            {
                Console.WriteLine("      " + myMeasure.sensorType.GetValue(i) + ": " + myMeasure.valueMeas.GetValue(i));
            }
            Console.ReadKey();
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
            }
            public string idSensor { get; set; }
            public Array sensorType { get; set; }
            public Array valueMeas { get; set; }
        }
    }
}
