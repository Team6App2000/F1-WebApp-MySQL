using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace F1_WebApp.Models
{
    public class RacesDataContext
    {
        public string ConnectionString { get; set; }

        public RacesDataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Races> GetAllRaces()
        {
            List<Races> list = new List<Races>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM RacesTest", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Races()
                        {
                            RaceName = reader["raceName"].ToString(),
                            Season = Convert.ToInt32(reader["season"]),
                            Round = reader["round"].ToString(),
                            Date = reader["date"].ToString(),
                            Time = reader["time"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}