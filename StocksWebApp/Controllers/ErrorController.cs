using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //action per controller

        public IActionResult Error(string error)
        {
            
            ViewBag.error = error;
            return View();
        }
    }
}
