using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.Controllers
{
    public class WalletController : Controller
    {
        public static readonly string connString = "Server=home.wietze.xyz;Database=RoelStam;User Id=RoelStam;Password=Test3211!";

        public IActionResult Index()
        {
            return View();
        }
    }
}
