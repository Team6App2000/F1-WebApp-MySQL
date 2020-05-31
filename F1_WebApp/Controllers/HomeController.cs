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
            DriversDataContext context = HttpContext.RequestServices.GetService(typeof(DriversDataContext)) as DriversDataContext;

            return View(context.GetAllDriversTest());
        }
    }
}