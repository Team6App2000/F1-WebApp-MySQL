using System;

namespace F1_WebApp.Models
{
    public class Drivers
    {
        //    private DriversDataContext context;

        public string DriverID { get; set; }

        public string URL { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string DateOfBirth { get; set; }

        public string Nationality { get; set; }
    }
}