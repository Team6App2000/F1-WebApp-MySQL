using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace F1_WebApp.Models
{
    public class ResultsDataContext
    {
        public string ConnectionString { get; set; }

        public ResultsDataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Results> GetAllResults()
        {
            List<Results> list = new List<Results>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ResultsTest", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Results()
                        {
                            ConstructorID = reader["constructorId"].ToString(),
                            RaceName = reader["raceName"].ToString(),
                            DriverID = reader["driverId"].ToString(),
                            Number = Convert.ToInt32(reader["number"]),
                            Position = Convert.ToInt32(reader["position"]),
                            Points = Convert.ToInt32(reader["points"]),
                            Grid = Convert.ToInt32(reader["grid"]),
                            Laps = Convert.ToInt32(reader["laps"]),
                            Status = reader["status"].ToString(),
                        });
                    }
                }
            }
            return list;
        }
    }
}