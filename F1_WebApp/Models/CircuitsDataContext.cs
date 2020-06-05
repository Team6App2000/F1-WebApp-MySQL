using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace F1_WebApp.Models
{
    public class CircuitsDataContext
    {
        public string ConnectionString { get; set; }

        public CircuitsDataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Circuits> GetAllCircuits()
        {
            List<Circuits> list = new List<Circuits>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM CircuitsTest", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Circuits()
                        {
                            CircuitName = reader["circuitName"].ToString(),
                            Location = reader["location"].ToString(),
                            Country = reader["country"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}