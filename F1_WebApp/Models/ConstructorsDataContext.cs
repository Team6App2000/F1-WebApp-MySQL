using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace F1_WebApp.Models
{
    public class ConstructorsDataContext
    {
        public string ConnectionString { get; set; }

        public ConstructorsDataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Constructors> GetAllConstructors()
        {
            List<Constructors> list = new List<Constructors>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ConstructorsTest", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Constructors()
                        {
                            ConstructorID = reader["constructorId"].ToString(),
                            URL = reader["url"].ToString(),
                            Name = reader["name"].ToString(),
                            Nationality = reader["nationality"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}