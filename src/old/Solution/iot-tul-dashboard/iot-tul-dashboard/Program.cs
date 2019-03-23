using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using IotShared;

namespace iot_tul_dashboard
{
    class Program
    {

        const string sqlQuery = "SELECT * FROM [dbo].[measurementsLog]";
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
                    Console.WriteLine("\nExecute {0} ...", sqlQuery);

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(sqlQuery);
                    String sql = sb.ToString();

                    Console.WriteLine("\nWrite data to collection...");
                    string json = null;
                    List<Measurement> kolekcja = new List<Measurement>();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Measurement odczyt = new Measurement();
                                odczyt.idMeas = reader.GetInt32(0);
                                odczyt.idSensor = reader.GetInt32(1);
                                odczyt.dateMeas = reader.GetDateTime(2);
                                odczyt.valueMeas = reader.GetFloat(3);
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
            Console.WriteLine("\nPress any key to exit...\n");

            Console.ReadKey();
        }
    }
}