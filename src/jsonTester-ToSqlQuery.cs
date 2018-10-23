using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            string json = @"{""measure"":{""idSensor"":""1"",""sensorType"":[""temp1"",""press1"",""hum1""],""valueMeas"":[""22.2"",""33,3"",""44,4.4""]}}"; //sample Json
            Measure myMeasure = new Measure(json);
            Console.WriteLine("idSensor : " + myMeasure.idSensor);
            Console.WriteLine("dateMeas : " + myMeasure.dateMeas);
            Console.WriteLine("Data: sensorType + valueMeas");
            for (int i = 0; i < myMeasure.sensorType.Length; i++)
            {
                string tempString = myMeasure.valueMeas.GetValue(i).ToString().Replace('.', ',');
                double temp = -2;
                if (double.TryParse(tempString, out temp) == true)
                {
                Console.WriteLine("      " + myMeasure.sensorType.GetValue(i) + ": " + temp); // myMeasure.valueMeas.GetValue(i));
                string temp_query = $"INSERT INTO dbo.measurementsLog(idSensor, dateMeas, sensorType, valueMeas) " +
                        $"VALUES({myMeasure.idSensor},{myMeasure.dateMeas},{myMeasure.sensorType.GetValue(i).ToString()},{temp.ToString().Replace(',','.')});";
                Console.WriteLine(temp_query);
                }
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
                DateTime myDateTime = DateTime.Now;
                dateMeas = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"); // date is prepare when Json is parsed; date is string, not DateTime
            }
            public string idSensor { get; set; }
            public string dateMeas { get; set; }
            public Array sensorType { get; set; }
            public Array valueMeas { get; set; }
        }

        //private static double randomuj(string v)
        //{
        //    if (v == "temp1") return getNumber(15, 25, rnd);
        //    else if (v == "hum1") return getNumber(30, 50, rnd);
        //    else if (v == "press1") return getNumber(980, 1020, rnd);
        //    else return -3;
        //}

        //public static float getNumber(int a, int b, Random _rnd)
        //{
        //    return (float)_rnd.Next(a, b) + (float)((float)_rnd.Next(0, 99) / 100);
        //}
    }
}
