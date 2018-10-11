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
                    Console.WriteLine("\nSELECT * FROM [dbo].[sensors01] ...");
                    //Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM [dbo].[sensors01]");
                    String sql = sb.ToString();

                    Console.WriteLine("\nWrite data to collection...");
                    string json = null;
                    List<SensorData> kolekcja = new List<SensorData>();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SensorData odczyt = new SensorData();
                                odczyt.ID = reader.GetInt32(0);
                                odczyt.SensorId = reader.GetInt32(1);
                                odczyt.Description = reader.GetString(2);
                                odczyt.Value = reader.GetInt32(3);
                                kolekcja.Add(odczyt);
                            }
                        }

                    }
                    Console.WriteLine("\nRewrite collection to json string...\n");
                    json = JsonConvert.SerializeObject(kolekcja);
                    Console.WriteLine(json);
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