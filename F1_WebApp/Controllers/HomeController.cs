using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace F1_WebApp
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ResultsDataContext context = HttpContext.RequestServices.GetService(typeof(ResultsDataContext)) as ResultsDataContext;

            return View(context.GetAllResults());
        }

        public IActionResult Drivers()
        {
            DriversDataContext context = HttpContext.RequestServices.GetService(typeof(DriversDataContext)) as DriversDataContext;

            return View(context.GetAllDrivers());
        }

        public IActionResult Circuits()
        {
            CircuitsDataContext context = HttpContext.RequestServices.GetService(typeof(CircuitsDataContext)) as CircuitsDataContext;

            return View(context.GetAllCircuits());
        }

        public IActionResult Constructors()
        {
            ConstructorsDataContext context = HttpContext.RequestServices.GetService(typeof(ConstructorsDataContext)) as ConstructorsDataContext;

            return View(context.GetAllConstructors());
        }

        public IActionResult Races()
        {
            RacesDataContext context = HttpContext.RequestServices.GetService(typeof(RacesDataContext)) as RacesDataContext;

            return View(context.GetAllRaces());
        }
    }
}