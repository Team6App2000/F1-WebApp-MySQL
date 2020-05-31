using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace F1_WebApp.Models
{
    public class DriversDataContext
    {
        public string ConnectionString { get; set; }

        public DriversDataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Drivers> GetAllDriversTest()
        {
            List<Drivers> list = new List<Drivers>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM DriversTest", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Drivers()
                        {
                            DriverID = reader["driverId"].ToString(),
                            URL = reader["url"].ToString(),
                            GivenName = reader["givenName"].ToString(),
                            FamilyName = reader["familyName"].ToString(),
                            DateOfBirth = reader["dateOfBirth"].ToString(),
                            Nationality = reader["nationality"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}