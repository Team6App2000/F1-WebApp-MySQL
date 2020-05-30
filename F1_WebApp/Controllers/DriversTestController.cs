using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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