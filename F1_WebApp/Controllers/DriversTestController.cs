using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace F1_WebApp
{
    public class DriversController : Controller
    {
        public IActionResult Index()
        {
            DriversTestDataContext context = HttpContext.RequestServices.GetService(typeof(DriversTestDataContext)) as DriversTestDataContext;

            return View(context.GetAllDriversTest());
        }
    }
}