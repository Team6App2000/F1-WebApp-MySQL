using System;

namespace F1_WebApp.Models
{
    public class Results
    {
        public string ConstructorID { get; set; }

        public string RaceName { get; set; }

        public string DriverID { get; set; }

        public int Number { get; set; }

        public int Position { get; set; }

        public int Points { get; set; }

        public int Grid { get; set; }

        public int Laps { get; set; }

        public string Status { get; set; }
    }
}