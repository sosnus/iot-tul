using System;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;

using System.Collections.Generic;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "iot-tul-dashboard-db.database.windows.net";
                builder.UserID = "tul-admin";
                builder.Password = "22DQqNdU";
                builder.InitialCatalog = "iot-tul-dashboard-db";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");


                    SensorData odczyt = new SensorData();
                    odczyt.ID = 1;
                    odczyt.SensorId = 1;
                    odczyt.Description = "AA";
                    odczyt.Value = 5;
                    List<SensorData> kolekcja = new List<SensorData> { odczyt, odczyt };
                    string json = JsonConvert.SerializeObject(kolekcja);
                    json += JsonConvert.SerializeObject(kolekcja);
                    Console.WriteLine(kolekcja);
                    Console.WriteLine(json);
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM [dbo].[sensors01]");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1} {2} {3}", reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}