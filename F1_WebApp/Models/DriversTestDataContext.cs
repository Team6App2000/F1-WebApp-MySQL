using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace F1_WebApp.Models
{
    public class DriversTestDataContext
    {
        public string ConnectionString { get; set; }

        public DriversTestDataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<DriversTest> GetAllDriversTest()
        {
            List<DriversTest> list = new List<DriversTest>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM DriversTest", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DriversTest()
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